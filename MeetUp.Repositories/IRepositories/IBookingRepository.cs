using System.Collections.Generic;
using System.Threading.Tasks;
using MeetUp.Data.models;

namespace MeetUp.Repositories.IRepositories
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetBookingByMeetUpIdAsync(int meetUpId);
        Task CreateBookingsAsync(List<Booking> bookngs);
    }
}
