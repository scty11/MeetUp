namespace MeetUp.Data.models
{
    public class Booking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int SeatId { get; set; }
        public int MeetUpId { get; set; }

        public Seat Seat { get; set; }
        public MeetUpDetail MeetUp { get; set; }
    }
}
