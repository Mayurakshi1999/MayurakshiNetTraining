// See https://aka.ms/new-console-template for more information

using System.ServiceProcess;
using WindowsServicesDotNetCore;

internal class LoggingService : ServiceBase
{
    private System.Timers.Timer _timer;
    public LoggingService()
    {
        _timer = new System.Timers.Timer();
    }

    protected override void OnStart(string[] args)
    {
        _timer.Enabled = true;
        _timer.Interval = TimeSpan.FromSeconds(1).TotalMilliseconds;
        _timer.Elapsed += _timer_Elapsed;
        base.OnStart(args);
        Logger.Log("Window Service is started");


    }

    private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
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
