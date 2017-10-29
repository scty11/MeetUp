using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetUp.Api.DTO
{
    public class BookingDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int MeetUpId { get; set; }
        public SeatDto Seat { get; set; }

    }
}
