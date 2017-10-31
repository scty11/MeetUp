using System.Collections.Generic;
using System.Threading.Tasks;
using MeetUp.Data.models;

namespace MeetUp.Services.ServiceInterfaces
{
    public interface IBookingService
    {
        Task CreateBookingAsync(List<Booking> bookings);
        Task<List<Booking>> GetBookingByMeetUpIdAsync(int meetUpId);
        Task<bool> CkeckEmailIsUniqueAsync(string email, int meetUpId);
        Task<bool> CkeckNameIsUniqueAsync(string name, int meetUpId);
    }
}
