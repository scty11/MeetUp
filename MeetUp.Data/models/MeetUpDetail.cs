using System;
using System.Collections.Generic;
using System.Text;

namespace MeetUp.Data.models
{
    public class MeetUpDetail
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
