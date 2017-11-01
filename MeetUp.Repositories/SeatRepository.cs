using System.Collections.Generic;
using System.Linq;
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
            return await _context.Seats.OrderBy(x => x.Row)
                .ThenBy(s => s.SeatNumber)
                .ToListAsync();
        }

        public async Task<List<Seat>> GetSeatsByIdsAsync(List<int> seatIds)
        {
            return await _context.Seats
                .Where(x => !seatIds.Contains(x.Id))
                .OrderBy(x => x.Row)
                .ThenBy(s => s.SeatNumber)
                .ToListAsync();
        }

        public async Task<List<Seat>> GetSeatsByIdsPageAsync(List<int> seatIds, int skip, int take)
        {
            return await _context.Seats
                .Where(x => !seatIds.Contains(x.Id))
                .OrderBy(x => x.Row)
                .ThenBy(s => s.SeatNumber)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }
    }
}
