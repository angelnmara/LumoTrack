using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LumoTrack.Model
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string MotherLastName { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity =
                await manager.CreateIdentityAsync(this,
                    DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
