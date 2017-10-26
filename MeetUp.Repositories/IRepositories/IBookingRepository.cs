using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Data.models;

namespace MeetUp.Repositories.IRepositories
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetBookingsAsync(DateTime date);
    }
}
