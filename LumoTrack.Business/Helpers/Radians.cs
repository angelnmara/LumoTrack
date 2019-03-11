using System;
using System.Collections.Generic;
using System.Text;

namespace LumoTrack.Business.Helpers
{
    public static class Radians
    {
        public static float Radiands(this float valor)
        {
            return Convert.ToSingle(Math.PI / 180) * valor;
        }
    }
}
