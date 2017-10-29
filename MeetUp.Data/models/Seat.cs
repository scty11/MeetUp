using System.Collections.Generic;

namespace MeetUp.Data.models
{
    public class Seat
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public string Row { get; set; }

        public ICollection<Booking> Bookings { get; set; }

    }
}
