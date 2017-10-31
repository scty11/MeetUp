using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetUp.Api.DTO.Booking
{
    public class CreateBokingsDto
    {
        public CreateBokingsDto()
        {
            CreateBookings = new List<CreateBookingDto>();
        }
        public List<CreateBookingDto> CreateBookings {get; set;}
    }
}
