using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetUp.Data.models;
using MeetUp.Repositories.IRepositories;
using MeetUp.Data.DBContext;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly MeetUpContext _context;

        public BookingRepository(MeetUpContext context)
        {
            _context = context;
        }

        public async Task CreateBookingsAsync(List<Booking> bookngs)
        {
            _context.AddRange(bookngs);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Booking>> GetBookingByMeetUpIdAsync(int meetUpId)
        {        
           
           return await _context.Bookings.Where(x => x.MeetUpId == meetUpId)
                .Include(x => x.Seat)
                .ToListAsync();

        }
    }
}
