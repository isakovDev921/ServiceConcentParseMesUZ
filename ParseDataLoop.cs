using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ServiceConcentParseMesUZ
{
    public static class ParseDataLoop
    {
        private static EventWaitHandle ev = null;

        public static Thread mainThreadlLoop = null;
        public static bool isRunLoop { set; get; } = true;
        public static void Run()
        {
           
        }

        public static void SetEv()
        {
            ev.Set();
        }
    }
}
