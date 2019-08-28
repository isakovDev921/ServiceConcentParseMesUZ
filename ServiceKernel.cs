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
                Console.WriteLine("Ошибка создания сервиса: " + er.Message);
            }
        }

        public void StartAsProgram(string[] args)
        {
            OnStart(args);
        }

        public void StopAsProgram()
        {
            OnStop();
        }



        protected override void OnStart(string[] args)
        {
            try
            {
                ParseDataLoop.mainThreadlLoop = new Thread(ParseDataLoop.Run);
                ParseDataLoop.mainThreadlLoop.Name = "ParseDataLoop";
                ParseDataLoop.mainThreadlLoop.Start();
               

            }
            catch (Exception er)
            {
                Console.WriteLine("ParseDataLoop: Ошибка запуска цикла: " + er.Message);               
            }            
        }
        protected override void OnStop()
        {
            try
            {
                if (ParseDataLoop.mainThreadlLoop != null)
                {
                    ParseDataLoop.isRunLoop = false;
                    ParseDataLoop.SetEv();
                }
            }
            catch (Exception er)
            {
                Console.WriteLine("ParseDataLoop: Ошибка остановки цикла: " + er.Message);
            }

        }
    }
}

// if (eventLog1 != null) eventLogJournal.WriteEntry("ServiceConcentParseMesUZ не найдена директория");
