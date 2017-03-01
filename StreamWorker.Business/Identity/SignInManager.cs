using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using StreamWorker.Data.Models;
using StreamWorker.Logic.Extensions;

namespace StreamWorker.Business.Identity
{
    public class SignInManager : SignInManager<StreamWorkerUser, int>
    {
        private SignInManager(StreamWorkerUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(StreamWorkerUser user)
        {
            return user.GenerateUserIdentityAsync((StreamWorkerUserManager) UserManager);
        }

        public static SignInManager Create(IdentityFactoryOptions<SignInManager> options, IOwinContext context)
        {
            return new SignInManager(context.GetUserManager<StreamWorkerUserManager>(), context.Authentication);
        }
    }
}