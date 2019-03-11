using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zorbek.Essentials.Data.Repositories;

namespace LumoTrack.Repository.Repositories
{
    public class RoleRepository : GenericRepository<IdentityRole, LumoTrackContext>
    {
        public RoleRepository(LumoTrackContext context) : base(context)
        {

        }


        public List<IdentityRole> GetListRoles()
        {
            var roles = context.Roles.ToList();

            return roles;
        }

        public string GetRoleNameByUser(string id)
        {
            var role = context.Roles.FirstOrDefault(x => x.Users.Any(z => z.UserId == id));

            return role.Name;
        }
    }
}
