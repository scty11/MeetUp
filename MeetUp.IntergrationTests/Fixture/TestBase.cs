using MeetUp.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace MeetUp.IntergrationTests.Fixture
{
    public class TestsBase : IDisposable
    {
        private TestServer _server;
        public HttpClient Client { get; private set; }
        public TestsBase()
        {
            // Do "global" initialization here; Called before every test method.
            SetUpClient();
        }

        public void Dispose()
        {
            // Do "global" teardown here; Called after every test method.
            var file = $"{Directory.GetCurrentDirectory()}/MeetUp.sqlite";
            if (File.Exists(file))
            {
                File.Delete(file);
            }
            _server?.Dispose();
            Client?.Dispose();
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
