using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetUp.Data.DBContext;
using MeetUp.Data.models;
using MeetUp.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Repositories
{
    public class MeetUpRepository : IMeetUpRepository
    {
        private readonly MeetUpContext _context;

        public MeetUpRepository(MeetUpContext context)
        {
            _context = context;
        }
        public async Task<List<MeetUpDetail>> GetMeetUpsAsync()
        {
           return await _context.MeetUps.OrderByDescending(x => x.Date).ToListAsync();
        }

        public async Task<MeetUpDetail> GetMeetUpWithBookingsAsync(int id)
        {
            return await _context.MeetUps
                                 .Include(x => x.Bookings)
                                 .ThenInclude(x => x.Seat)
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
