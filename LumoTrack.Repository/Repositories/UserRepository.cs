using LumoTrack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zorbek.Essentials.Data.Repositories;

namespace LumoTrack.Repository.Repositories
{
    public class UserRepository : GenericRepository<User, LumoTrackContext>
    {
        public UserRepository(LumoTrackContext context) : base(context)
        {

        }


        public override User Create(User entity)
        {
            context.Users.Add(entity);

            context.SaveChanges();

            return entity;
        }

    }
}
