using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace StreamWorker.Core.Identity
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Hier den E-Mail-Dienst einfügen, um eine E-Mail-Nachricht zu senden.
            return Task.FromResult(0);
        }
    }

    // Konfigurieren des in dieser Anwendung verwendeten Anwendungsbenutzer-Managers. UserManager wird in ASP.NET Identity definiert und von der Anwendung verwendet.

    // Anwendungsanmelde-Manager konfigurieren, der in dieser Anwendung verwendet wird.
}