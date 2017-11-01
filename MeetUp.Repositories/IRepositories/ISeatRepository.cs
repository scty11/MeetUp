using System.Collections.Generic;
using System.Threading.Tasks;
using MeetUp.Data.models;

namespace MeetUp.Repositories.IRepositories
{
    public interface ISeatRepository
    {
        Task<List<Seat>> GetSeatsAsync();
        Task<List<Seat>> GetSeatsByIdsAsync(List<int> seatIds);
        Task<List<Seat>> GetSeatsByIdsPageAsync(List<int> seatIds, int skip, int take);
    }
}
