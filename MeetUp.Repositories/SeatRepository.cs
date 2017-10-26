using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Data.models;
using MeetUp.Repositories.IRepositories;
using MeetUp.Data.DBContext;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly MeetUpContext _context;

        public SeatRepository(MeetUpContext context)
        {
            _context = context;
        }
        public async Task<List<Seat>> GetSeatsAsync()
        {
            return await _context.Seats.ToListAsync();
        }
    }
}
