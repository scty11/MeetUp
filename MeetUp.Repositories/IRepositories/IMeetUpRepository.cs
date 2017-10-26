using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace MeetUp.Repositories.IRepositories
{
    public interface IMeetUpRepository
    {
        Task<List<Data.models.MeetUpDetail>> GetMeetUpsAsync();
        Task<Data.models.MeetUpDetail> GetMeetUpAsync(DateTime date);
    }
}
