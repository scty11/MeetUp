namespace MeetUp.Api.DTO.Booking
{
    public class CreateBookingDto
    {
       
        public int MeetUpId { get; set; }    
        public int SeatId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
