using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Data.models;

namespace MeetUp.Repositories.IRepositories
{
    public interface ISeatRepository
    {
        Task<List<Seat>> GetSeatsAsync();
        Task<List<Seat>> GetSeatsByIdsAsync(List<int> seatIds);
    }
}
