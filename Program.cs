using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServiceConcentParseMesUZ
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Start ...");

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new ServiceKernel()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
