using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace MeetUp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = BuildWebHost(args);

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
             .ConfigureLogging((hostingContext, builder) =>
             {
                 var configuration = hostingContext.Configuration.GetSection("Logging");
                 builder.AddFile(configuration);
             })
                .UseStartup<Startup>()                                  
                .Build();
    }
}
