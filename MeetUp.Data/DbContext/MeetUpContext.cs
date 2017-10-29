using MeetUp.Data.models;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Data.DBContext
{
    public class MeetUpContext : DbContext
    {
        public DbSet<models.MeetUpDetail> MeetUps { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Seat> Seats { get; set; }

        public MeetUpContext(DbContextOptions<MeetUpContext> options) : base(options) { }
    }
}
