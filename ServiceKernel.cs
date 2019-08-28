using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace ServiceConcentParseMesUZ
{
    public partial class ServiceKernel : ServiceBase
    {
        EventLog eventLogJournal = new EventLog();

        public ServiceKernel()
        {
            InitializeComponent();

            try
            {
                if (!EventLog.SourceExists("ServiceConcentParseMesUZsource"))
                {
                    EventLog.CreateEventSource("ServiceConcentParseMesUZsource", "ServiceConcentParseMesUZ");
                }
                eventLogJournal.Source = "ServiceConcentParseMesUZsource";
                eventLogJournal.Log = "ServiceConcentParseMesUZ";
            }
            catch (Exception er)
            {
                Console.WriteLine("Create service error: " + er.Message);
            }
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                ParseDataLoop.mainThreadlLoop = new Thread(ParseDataLoop.Run);
                ParseDataLoop.mainThreadlLoop.Name = "ParseDataLoop";
                ParseDataLoop.mainThreadlLoop.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка запуска цикла: " + e);
                
            }
            
        }

        protected override void OnStop()
        {
            try
            {
               
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка остановки цикла: " + e);
            }

        }
    }
}

// if (eventLog1 != null) eventLogJournal.WriteEntry("ServiceConcentParseMesUZ не найдена директория");
