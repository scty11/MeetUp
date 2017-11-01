using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using MeetUp.IntergrationTests.Fixture;
using Xunit;

namespace MeetUp.IntergrationTests
{
    public class PingTests 
    {
        private readonly TestContext _sut;

        public PingTests()
        {
            _sut = new TestContext();
        }

        [Fact]
        public async Task PingReturnsOkResponse()
        {
            var response = await _sut.Client.GetAsync("api/HealthCheck/ping");

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
