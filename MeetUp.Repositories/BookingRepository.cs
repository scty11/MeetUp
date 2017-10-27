using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Data.models;
using MeetUp.Repositories.IRepositories;
using MeetUp.Data.DBContext;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

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
               // _logger.LogError($"Error in {nameof(CreateBookingsAsync)}: " + exp.Message);
                throw;
            }
        }

        public Task<List<Booking>> GetBookingsAsync(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
