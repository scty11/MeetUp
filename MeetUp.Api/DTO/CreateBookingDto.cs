using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetUp.Api.DTO
{
    public class CreateBookingDto
    {
        [Required]
        public int MeetUpId { get; set; }
        [Required]
        public int SeatId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
