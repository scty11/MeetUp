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
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }      

        public async Task CreateBookingAsync(List<Booking> bookings)
        {
            await _bookingRepository.CreateBookingsAsync(bookings);
        }

        public async Task<bool> CkeckEmailIsUniqueAsync(string email, int meetUpId)
        {
            var bookings = await _bookingRepository.GetBookingByMeetUpIdAsync(meetUpId);
            if (bookings == null)
            {
                return true;
            }
            else
            {
                return !bookings.Any(x => string.Equals(x.Email, email, 
                                   StringComparison.OrdinalIgnoreCase));
            }
        }

        public async Task<bool> CkeckNameIsUniqueAsync(string name, int meetUpId)
        {
            var bookings = await _bookingRepository.GetBookingByMeetUpIdAsync(meetUpId);
            if (bookings == null)
            {
                return true;
            }
            else
            {
                return !bookings.Any(x => string.Equals(x.Name, name, 
                                  StringComparison.OrdinalIgnoreCase));
            }
        }

        public async Task<List<Booking>> GetBookingByMeetUpIdAsync(int meetUpId)
        {
           return  await _bookingRepository.GetBookingByMeetUpIdAsync(meetUpId);
        }
    }
}
