using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Data.models;
using MeetUp.Repositories.IRepositories;

namespace MeetUp.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        public Task<List<Booking>> GetBookingsAsync(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
