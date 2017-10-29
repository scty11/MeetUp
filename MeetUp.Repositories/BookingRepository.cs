using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetUp.Data.models;
using MeetUp.Repositories.IRepositories;
using MeetUp.Data.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MeetUp.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly MeetUpContext _context;
        private readonly ILogger _logger;

        public BookingRepository(MeetUpContext context)
        {
            _context = context;
        }

        public async Task CreateBookingsAsync(List<Booking> bookngs)
        {
            _context.AddRange(bookngs);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Exception exp)
            {
                _logger.LogError($"Error in {nameof(CreateBookingsAsync)}: " + exp.Message);
                throw;
            }
        }

        public async Task<List<Booking>> GetBookingByMeetUpIdAsync(int meetUpId)
        {
           
            try
            {
               return await _context.Bookings.Where(x => x.MeetUpId == meetUpId)
                    .ToListAsync();
            }
            catch (System.Exception exp)
            {
                _logger.LogError($"Error in {nameof(GetBookingByMeetUpIdAsync)}: " + exp.Message);
                throw;
            }
        }
    }
}
