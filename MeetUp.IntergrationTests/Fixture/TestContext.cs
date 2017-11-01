using System.IO;
using System.Net.Http;
using MeetUp.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace MeetUp.IntergrationTests.Fixture
{
    public class TestContext
    {
        private TestServer _server;
        public HttpClient Client { get; private set; }

        public TestContext()
        {
            SetUpClient();
        }

        private void SetUpClient()
        {
            _server = new TestServer(new WebHostBuilder()

                    .UseEnvironment("Development")
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseConfiguration(new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .AddJsonFile("appsettings.Development.json")
                        .Build()
                    )                
                .UseStartup<Startup>());

            Client = _server.CreateClient();

        }
    }
}
