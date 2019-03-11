using LumoTrack.Repository;
using LumoTrack.Repository.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LumoTrack.Business
{
    public class RoleBusiness
    {
        private LumoTrackContext _lumoTrackContext;

        private readonly RoleRepository _roleRepository;

        public RoleBusiness()
        {
            _lumoTrackContext = new LumoTrackContext();
            _roleRepository = new RoleRepository(_lumoTrackContext);
        }


        public List<IdentityRole> GetList()
        {
           var result= _roleRepository.GetList();

            return result.ToList();
        }
    }
}
