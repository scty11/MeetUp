using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Data.models;

namespace MeetUp.Services.ServiceInterfaces
{
    public interface IBookingService
    {
        Task<List<MeetUpDetail>> GetMeetUpsAsync();
        Task<List<Seat>> GetSeatsAsync();
        Task<List<Booking>> GetBookingsAsync(DateTime date);

    }
}
