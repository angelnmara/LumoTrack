using LumoTrack.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zorbek.essentials.datatest;

namespace LumoTrack.Business.Test
{
    public abstract class BaseBusinessTest :GlobalTest<LumoTrackContext>
    {
        protected LumoTrackContext _dbContext;

        public NotificationBusiness _notificationBusiness;


        public BaseBusinessTest()
        {
            InitializeContext();
        }

        [AssemblyInitialize]
        public static void InitializeDatabase(TestContext context)
        {
            InitDatabase(context);
        }

    }
}
