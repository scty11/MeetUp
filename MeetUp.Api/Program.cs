using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using MeetUp.Data.DBSeed;
using Microsoft.Extensions.Logging;

namespace MeetUp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = BuildWebHost(args);
            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //        EnsureDataStorageIsReady(services);
            //}
            
            host.Run();
        }

        private static void EnsureDataStorageIsReady(IServiceProvider services)
        {
            MeetUpDbSeeder.SeedAsync(services).Wait();
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
