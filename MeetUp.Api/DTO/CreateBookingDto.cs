using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetUp.Api.DTO
{
    public class CreateBookingDto
    {
        public int MeetUpId { get; set; }
        public int SeatId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
