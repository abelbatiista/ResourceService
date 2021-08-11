using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using BusinessLogic;

namespace ResourceService
{
    public partial class ResourceServiceMainClass : ServiceBase
    {

        private readonly Timer timer;
        private readonly Logic _service;

        public ResourceServiceMainClass()
        {
            InitializeComponent();
            timer = new Timer();
            _service = new Logic();
        }

        protected override void OnStart(string[] args)
        {

            WrittingToFile($"The service was started at {DateTime.Now:dd/MM/yyyy hh:mm:ss}");
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 60000; //(1000 * 60 * 5); //Miliseconds value.
            timer.Enabled = true;

        }

        protected override void OnStop()
        {

            WrittingToFile($"The service was stopped at {DateTime.Now:dd/MM/yyyy hh:mm:ss}");

        }

        private async void OnElapsedTime(object source, ElapsedEventArgs e)
        {

            WrittingToFile($"The service was executed again at {DateTime.Now:dd/MM/yyyy hh:mm:ss}");
            await _service.ServiceExecution();

        }

        private void WrittingToFile(string message)
        {

            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.ToShortDateString().Replace("/", "-") + ".txt";

            if (!File.Exists(filepath))
            {
                using (StreamWriter streamWriter = File.CreateText(filepath))
                {
                    streamWriter.WriteLine(message);
                }
            }
            else
            {
                using (StreamWriter streamWriter = File.AppendText(filepath))
                {
                    streamWriter.WriteLine(message);
                }
            }

        }

    }
}
