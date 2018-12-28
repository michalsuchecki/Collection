using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;


namespace Collection.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                          .UseStartup<Startup>()
                          .ConfigureLogging(l =>
                          {
                              l.ClearProviders();
                              l.SetMinimumLevel(LogLevel.Trace);
                          })
                          .UseNLog()
                          .Build();
        }
    }
}
