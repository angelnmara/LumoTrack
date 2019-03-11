using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LumoTrack.Model;
using System.Data.Entity;

namespace LumoTrack.Repository
{
    public class LumoTrackContext : IdentityDbContext<User, IdentityRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Inbox> Inbox { get; set; }
        public DbSet<Devices> Device { get; set; }

        public LumoTrackContext(string connectionString) : base(connectionString)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public LumoTrackContext() : base("name=LumoTrackContextConnectionString")
        {
            Database.SetInitializer<LumoTrackContext>(null);
        }

        public static LumoTrackContext Create()
        {
            return new LumoTrackContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            base.OnModelCreating(modelBuilder);
        }

    }
}
