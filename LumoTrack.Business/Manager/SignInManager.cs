using System;
using System.Security.Claims;
using System.Threading.Tasks;
using LumoTrack.DTO;
using LumoTrack.Model;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace LumoTrack.Business.Manager
{
    public class SignInManager : SignInManager<User, string>
    {
        public SignInManager(UserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return user.GenerateUserIdentityAsync((UserManager)UserManager);
        }

        public static SignInManager Create(IdentityFactoryOptions<SignInManager> options, IOwinContext context)
        {
            return new SignInManager(context.GetUserManager<UserManager>(), context.Authentication);
        }

        public Task SignInAsync(UserDTO user, bool isPersistent, bool rememberBrowser)
        {
            throw new NotImplementedException();
        }
    }
}
