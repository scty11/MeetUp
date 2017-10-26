using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Data.DBContext;
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
        public async Task<List<Data.models.MeetUpDetail>> GetMeetUpsAsync()
        {
           return await _context.MeetUps.OrderByDescending(x => x.Date).ToListAsync();
        }

        public Task<Data.models.MeetUpDetail> GetMeetUpAsync(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
