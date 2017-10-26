using System;
using System.Collections.Generic;
using System.Text;

namespace MeetUp.Data.models
{
    public class Booking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Seat Seat { get; set; }
        public MeetUpDetail MeetUp { get; set; }
    }
}
