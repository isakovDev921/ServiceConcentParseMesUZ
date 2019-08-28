using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceProcess;
using System.Configuration.Install;

namespace ServiceConcentParseMesUZ
{
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        ServiceInstaller serviceInstaller;
        ServiceProcessInstaller processInstaller;
        public Installer1()
        {
            InitializeComponent();
            serviceInstaller = new ServiceInstaller();
            processInstaller = new ServiceProcessInstaller();

            processInstaller.Account = ServiceAccount.LocalSystem;
            processInstaller.Password = "";
            processInstaller.Username = "";

            serviceInstaller.StartType = ServiceStartMode.Manual;
            serviceInstaller.ServiceName = "ServiceConcentParseMesUZ";          
            serviceInstaller.DisplayName = "Служба обработки автоответов УЗ";
            serviceInstaller.Description = "11111111111111111111111111111111111111111111";

            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
