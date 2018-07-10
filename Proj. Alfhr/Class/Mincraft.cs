using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Alfhr.Control
{
    class Mincraft
    {
        private static String ClientPath = "";
        private static String Command = "";

        private static Task LaunchAsync()
        {
            return Task.Run(() => Launch());
        }

        public static void Launch()
        {

        }

        public static async Task Update()
        {

        }
    }
}
