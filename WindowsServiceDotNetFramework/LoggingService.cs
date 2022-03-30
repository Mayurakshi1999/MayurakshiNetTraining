using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsServiceDotNetFramework
{
    public partial class LoggingService : ServiceBase
    {
        private Timer _timer;
        public LoggingService()
        {
            InitializeComponent();
            _timer = new Timer();
        }

        protected override void OnStart(string[] args)
        {
            _timer.Enabled = true;
            _timer.Interval = TimeSpan.FromSeconds(1).TotalMilliseconds;
            _timer.Elapsed += _timer_Elapsed;
            base.OnStart(args);
            Logger.Log("Window Service is started");

                
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Interval=TimeSpan.FromSeconds(10).TotalMilliseconds;
            BatchJob();
        }
        public void BatchJob()
        {
            Logger.Log("Batch Job is Started");
        }

        protected override void OnStop()
        {
            _timer.Enabled = false;
            _timer.Dispose();
            _timer = null;
            base.OnStop();
            Logger.Log("Window service is stopped");
        }
    }
}
