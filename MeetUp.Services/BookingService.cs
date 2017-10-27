using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetUp.Data.models;
using MeetUp.Repositories.IRepositories;
using MeetUp.Services.ServiceInterfaces;

namespace MeetUp.Services
{
    public class BookingService : IBookingService
    {
        private readonly IMeetUpRepository _meetUpRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IMeetUpRepository meetUpRepository, ISeatRepository seatRepository, IBookingRepository bookingRepository)
        {
            _meetUpRepository = meetUpRepository;
            _seatRepository = seatRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<List<MeetUpDetail>> GetMeetUpsAsync()
        {
            return await _meetUpRepository.GetMeetUpsAsync();
        }

        public async Task<MeetUpDetail> GetMeetUpAsync(int id)
        {
           return await _meetUpRepository.GetMeetUpWithBookingsAsync(id);
        }

        public async Task CreateBookingAsync(List<Booking> bookings)
        {
            await _bookingRepository.CreateBookingsAsync(bookings);
        }

        public async Task<List<Seat>> GetSeatsAsync()
        {
            return await _seatRepository.GetSeatsAsync();
        }

        public async Task<List<Seat>> GetavailableSeatsAsync(int id)
        {
            var bookedSeatsIds = new List<int>();
            var bookedSeats = new List<Seat>();

            var meetUp = await _meetUpRepository.GetMeetUpWithBookingsAsync(id);

            if (meetUp == null) return bookedSeats;

            bookedSeatsIds = meetUp.Bookings.Select(x => x.Seat.Id).ToList();
            bookedSeats = await _seatRepository.GetSeatsByIdsAsync(bookedSeatsIds);

            return bookedSeats;
        }

    }
}
