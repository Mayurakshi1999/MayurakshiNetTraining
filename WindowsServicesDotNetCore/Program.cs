// See https://aka.ms/new-console-template for more information

using System.ServiceProcess;

ServiceBase[] ServicesToRun;
ServicesToRun = new ServiceBase[]
{
                new LoggingService()
};
ServiceBase.Run(ServicesToRun);