using System.Collections.Generic;
using FluentAssertions;
using MeetUp.Data.models;
using MeetUp.Repositories.IRepositories;
using MeetUp.Services;
using Moq;
using NUnit.Framework;

namespace MeetUp.UnitTests
{
    public class UnitTest1
    {
        private Mock<IBookingRepository> _bookingRepoMock;

        [SetUp]
        public void Setup()
        {
            _bookingRepoMock = new Mock<IBookingRepository>();
        }

        [Test]
        public void WhenEmail_IsNotUniqueForBooking_ShouldReturnFalse()
        {            
            _bookingRepoMock.Setup(x => x.GetBookingByMeetUpIdAsync(It.IsAny<int>())).ReturnsAsync(
                new List<Booking>(){new Booking(){Email = "Test@Test.com"}});

            var bookingService = new BookingService(_bookingRepoMock.Object);

            var result = bookingService.CkeckEmailIsUniqueAsync("Test@Test.com", 1).Result;

            result.Should().Be(false);
        }

        [Test]
        public void WhenName_IsNotUniqueForBooking_ShouldReturnFalse()
        {
            _bookingRepoMock.Setup(x => x.GetBookingByMeetUpIdAsync(It.IsAny<int>())).ReturnsAsync(
                new List<Booking>() { new Booking() { Name = "User1" } });

            var bookingService = new BookingService(_bookingRepoMock.Object);

            var result = bookingService.CkeckNameIsUniqueAsync("User1", 1).Result;

            result.Should().Be(false);
        }
    }
}
