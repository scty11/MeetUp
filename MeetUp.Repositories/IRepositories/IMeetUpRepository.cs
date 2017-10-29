using System.Collections.Generic;
using System.Threading.Tasks;
using MeetUp.Data.models;


namespace MeetUp.Repositories.IRepositories
{
    public interface IMeetUpRepository
    {
        Task<List<MeetUpDetail>> GetMeetUpsAsync();
        Task<MeetUpDetail> GetMeetUpWithBookingsAsync(int id);
    }
}
