using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetUp.Api.DTO
{
    public class MeetUpAvailabilityDto
    {
        public MeetUpAvailabilityDto()
        {
            this.AvailableSeats = new List<SeatDto>();
        }

        public DateTime Date { get; set; }
        public List<SeatDto> AvailableSeats { get; set; }

    }
}
