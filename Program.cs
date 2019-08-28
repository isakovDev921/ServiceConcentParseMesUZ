using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ServiceConcentParseMesUZ
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Start ...");

            if (!args.Contains("run=1"))
            {

                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new ServiceKernel()
                };
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                ServiceKernel conRun;
                conRun = new ServiceKernel();
                conRun.StartAsProgram(args);


                //    Thread.Sleep(500);
                //    bool isLoop = true;
                //    while (isLoop)
                //    {
                //        Thread.Sleep(1000);
                //    }
                Console.WriteLine("Finish ...");
                Console.ReadLine();
            }
        }
    }


    [RunInstaller(true)]
    public class WindowsServiceInstaller : System.Configuration.Install.Installer
    {
        public WindowsServiceInstaller()
        {
            ServiceProcessInstaller processInstaller = new ServiceProcessInstaller();
            processInstaller.Account = ServiceAccount.LocalSystem;

            ServiceInstaller serviceInstaller = new ServiceInstaller();
            processInstaller.Password = "";
            processInstaller.Username = "";
            processInstaller.Account = ServiceAccount.LocalSystem;

            serviceInstaller.DisplayName = "Служба обработки автоответов УЗ";
            serviceInstaller.ServiceName = "ServiceConcentParseMes";
            serviceInstaller.Description = "Сервис обрабатывает данные и передает их в сервис записи в БД";

            serviceInstaller.StartType = ServiceStartMode.Automatic;

            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }

}
