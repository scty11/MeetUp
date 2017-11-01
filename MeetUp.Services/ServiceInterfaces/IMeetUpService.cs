using System.Collections.Generic;
using System.Threading.Tasks;
using MeetUp.Data.models;

namespace MeetUp.Services.ServiceInterfaces
{
    public interface IMeetUpService
    {
        Task<List<MeetUpDetail>> GetMeetUpsAsync();
        Task<List<Seat>> GetSeatsAsync();
        Task<List<Seat>> GetAvailableSeatsAsync(int id);
        Task<MeetUpDetail> GetMeetUpAsync(int id);
        Task<List<Seat>> GetAvailableSeatsPageAsync(int meetUpId, int skip, int take);

    }
}
