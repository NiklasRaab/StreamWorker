using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using StreamWorker.Data.Models;

namespace StreamWorker.Logic.Extensions
{
    public static class StreamWorkerUserExtensions
    {
        public static async Task<ClaimsIdentity> GenerateUserIdentityAsync(this StreamWorkerUser streamWorkerUser,
            UserManager<StreamWorkerUser, int> manager)
        {
            // Beachten Sie, dass der "authenticationType" mit dem in "CookieAuthenticationOptions.AuthenticationType" definierten Typ übereinstimmen muss.
            var userIdentity =
                await manager.CreateIdentityAsync(streamWorkerUser, DefaultAuthenticationTypes.ApplicationCookie);
            // Benutzerdefinierte Benutzeransprüche hier hinzufügen
            return userIdentity;
        }
    }
}