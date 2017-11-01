namespace MeetUp.Api.DTO.Booking
{
    public class BookingDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int MeetUpId { get; set; }
        public int SeatId { get; set; }
        public SeatDto Seat { get; set; }

    }
}
