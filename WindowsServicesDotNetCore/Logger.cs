using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServicesDotNetCore
{
    public class Logger
    {
        static string _file = @"C:\Users\paulm\source\repos\Logs\WindowsServiceDotNetCore.log";
        static readonly object _lckObj = new object();
        public static void Log(string msg)
        {
            lock (_lckObj)
            {
                using (var writer = new StreamWriter(_file, true, Encoding.UTF8))
                {
                    var full_msg = $"{DateTime.Now.ToString()} {DateTime.Now.ToLongTimeString()} {msg}";
                    writer.WriteLine(full_msg);
                    writer.Close();
                    writer.Dispose();
                }
            }
        }
    }
}
