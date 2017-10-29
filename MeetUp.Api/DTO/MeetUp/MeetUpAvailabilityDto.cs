using System;
using System.Collections.Generic;

namespace MeetUp.Api.DTO.MeetUp
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
