using System;
using System.Collections.Generic;
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

        public BookingService(IMeetUpRepository meetUpRepository, ISeatRepository seatRepository)
        {
            _meetUpRepository = meetUpRepository;
            _seatRepository = seatRepository;
        }

        public async Task<List<MeetUpDetail>> GetMeetUpsAsync()
        {
            return await _meetUpRepository.GetMeetUpsAsync();
        }

        public async Task<List<Seat>> GetSeatsAsync()
        {
            return await _seatRepository.GetSeatsAsync();
        }

        public Task<List<Booking>> GetBookingsAsync(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
