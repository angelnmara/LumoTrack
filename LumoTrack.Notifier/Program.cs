using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LumoTrack.Business;

namespace LumoTrack.Notifier
{
    class Program
    {
        static void Main(string[] args)
        {
            var notifier = new NotifierDevices();

            var devices = notifier.Start();

            Console.WriteLine("Finish");
        }
    }
}
