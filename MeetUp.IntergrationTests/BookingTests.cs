using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using MeetUp.Api.DTO.Booking;
using MeetUp.IntergrationTests.Fixture;
using Xunit;
using MeetUp.IntergrationTests.Exstensions;
using Newtonsoft.Json;

namespace MeetUp.IntergrationTests
{
    [Collection("SystemCollection")]
    public class BookingTests 
    {
        private readonly TestsBase _sut;

        public BookingTests(TestsBase testsBase)
        {
            _sut = testsBase;
        }

        [Fact]
        public async Task WhenCreateCalled_WithEmailUsed_ShouldReturnBadRequest()
        {
           var bookings = new List<CreateBookingDto>(){new CreateBookingDto()
            {
                Email = "test1@test.com",MeetUpId = 1,Name = "scotty",SeatId = 16
            }};

            var response = await _sut.Client.PostAsJsonAsync("api/Booking", bookings);
            var contents = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            contents.Should().Contain("Email is already present on a booking");
        }

        [Fact]
        public async Task WhenCreateCalled_WithNameUsed_ShouldReturnBadRequest()
        {
            var bookings = new List<CreateBookingDto>(){new CreateBookingDto()
            {
                Email = "test1@test.com",MeetUpId = 1,Name = "test1",SeatId = 16
            }};

            var response = await _sut.Client.PostAsJsonAsync("api/Booking", bookings);
            var contents = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            contents.Should().Contain("Name is already present on a booking");
        }

        [Fact]
        public async Task WhenCreateCalled_WithSeatUsed_ShouldReturnBadRequest()
        {
            var bookings = new List<CreateBookingDto>(){new CreateBookingDto()
            {
                Email = "test50@test.com",MeetUpId = 1,Name = "test50",SeatId = 1
            }};

            var response = await _sut.Client.PostAsJsonAsync("api/Booking", bookings);
            var contents = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            contents.Should().Contain("The seat is not available");
        }

        [Fact]
        public async Task WhenCreateCalled_WithRepeatedSeatsInList_ShouldReturnBadRequest()
        {
            var bookings = new List<CreateBookingDto>() {new CreateBookingDto()
            {
                Email = "test50@test.com",
                MeetUpId = 1,
                Name = "test50",
                SeatId = 10
            },new CreateBookingDto()
            {
                Email = "test50@test.com",
                MeetUpId = 1,
                Name = "test51",
                SeatId = 10
            }
            };          

            var response = await _sut.Client.PostAsJsonAsync("api/Booking", bookings);
            var contents = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            contents.Should().Contain("You cannot book the same seat");
        }

        [Fact]
        public async Task WhenCreateCalled_WithValidBookings_ShouldReturnOk()
        {
            var bookings = new List<CreateBookingDto>(){new CreateBookingDto()
            {
                Email = "test50@test.com",MeetUpId = 1,Name = "test50",SeatId = 16
            }};
            var response = await _sut.Client.PostAsJsonAsync("api/Booking", bookings);
            var contents = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            response = await _sut.Client.GetAsync("api/Booking/BookingByMeetUp/1");
            contents = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<BookingDto>>(contents);

            result.Should().Contain(x => x.SeatId == 16);
        }
    }
}
