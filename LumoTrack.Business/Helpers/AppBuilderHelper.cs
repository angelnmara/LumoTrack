using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LumoTrack.Business.Manager;
using LumoTrack.Model;
using LumoTrack.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace LumoTrack.Business.Helpers
{
    public class AppBuilderHelper
    {
        public static void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(LumoTrackContext.Create);
            app.CreatePerOwinContext<UserManager>(UserManager.Create);
            app.CreatePerOwinContext<SignInManager>(SignInManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<UserManager, User>(
                        TimeSpan.FromMinutes(60),
                        (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
        }
    }
}
