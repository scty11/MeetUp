using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MeetUp.Api.DTO.Booking;
using MeetUp.IntergrationTests.Fixture;
using Newtonsoft.Json;
using Xunit;

namespace MeetUp.IntergrationTests
{
    public class BookingTests
    {
        private readonly TestContext _sut;

        public BookingTests()
        {
            _sut = new TestContext();
        }

        [Fact]
        public async Task WhenCreateCalled_WithVEmailUsed_ShouldReturnBadRequest()
        {
           var obj = JsonConvert.SerializeObject(new List<CreateBookingDto>(){new CreateBookingDto()
            {
                Email = "test1@test.com",MeetUpId = 1,Name = "scotty",SeatId = 16
            }});

            var response = await _sut.Client.PostAsync("api/Booking", 
                new StringContent(obj, Encoding.UTF8, "application/json"));
            var contents = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            contents.Should().Contain("Email is already present on a booking");
        }
    }
}
