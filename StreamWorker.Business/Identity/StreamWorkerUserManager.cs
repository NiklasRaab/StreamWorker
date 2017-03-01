using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using StreamWorker.Core.Identity;
using StreamWorker.Data.DataContext;
using StreamWorker.Data.Models;

namespace StreamWorker.Business.Identity
{
    public class StreamWorkerUserManager : UserManager<StreamWorkerUser, int>
    {
        private StreamWorkerUserManager(IUserStore<StreamWorkerUser, int> store)
            : base(store)
        {
        }

        public static StreamWorkerUserManager Create(IdentityFactoryOptions<StreamWorkerUserManager> options,
            IOwinContext context)
        {
            var manager =
                new StreamWorkerUserManager(
                    new UserStore
                    <StreamWorkerUser, StreamWorkerRole, int, StreamWorkerUserLogin, StreamWorkerUserRole,
                        StreamWorkerUserClaim>(context.Get<StreamWorkerDataContext>()));
            // Konfigurieren der Überprüfungslogik für Benutzernamen.
            manager.UserValidator = new UserValidator<StreamWorkerUser, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Konfigurieren der Überprüfungslogik für Kennwörter.
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true
            };

            // Standardeinstellungen für Benutzersperren konfigurieren
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Registrieren von Anbietern für zweistufige Authentifizierung. Diese Anwendung verwendet telefonische und E-Mail-Nachrichten zum Empfangen eines Codes zum Überprüfen des Benutzers.
            // Sie können Ihren eigenen Anbieter erstellen und hier einfügen.
            manager.RegisterTwoFactorProvider("Telefoncode", new PhoneNumberTokenProvider<StreamWorkerUser, int>
            {
                MessageFormat = "Ihr Sicherheitscode lautet {0}"
            });
            manager.RegisterTwoFactorProvider("E-Mail-Code", new EmailTokenProvider<StreamWorkerUser, int>
            {
                Subject = "Sicherheitscode",
                BodyFormat = "Ihr Sicherheitscode lautet {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<StreamWorkerUser, int>(
                        dataProtectionProvider.Create("ASP.NET Identity"));
            return manager;
        }
    }
}