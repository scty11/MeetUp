namespace MeetUp.Api.DTO.Booking
{
    public class CreateBookingDto
    {
        [Required]
        public int MeetUpId { get; set; }
        [Required]
        public int SeatId { get; set; }
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
