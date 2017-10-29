using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeetUp.Data.DBContext;
using MeetUp.Data.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MeetUp.Data.DBSeed
{
    public class MeetUpDbSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var meetUpDb = serviceScope.ServiceProvider.GetService<MeetUpContext>();

                if (!await meetUpDb.Seats.AnyAsync())
                {
                    await InsertSeatSampleData(meetUpDb);
                }

                if (!await meetUpDb.MeetUps.AnyAsync())
                    {
                        await InsertMeetUpSampleData(meetUpDb);
                    }
 
                  

            }
        }

        private static async Task InsertSeatSampleData(MeetUpContext meetUpDb)
        {
            var seats = GetSeats();
            meetUpDb.Seats.AddRange(seats);
            try
            {
                await meetUpDb.SaveChangesAsync();

            }
            catch (Exception exp)
            {
                //todo log error
                throw;
            }
        }


        private static async Task InsertMeetUpSampleData(MeetUpContext meetUpDb)
        {
            var meetUps = GetMeetUps();
            meetUpDb.MeetUps.AddRange(meetUps);
            try
            {
                await meetUpDb.SaveChangesAsync();
                
            }
            catch (Exception exp)
            {
               //todo log error
                throw;
            }
        }

        private static List<MeetUpDetail> GetMeetUps()
        {
            return new List<MeetUpDetail>()
            {
                new MeetUpDetail(){Date = DateTime.Today, Bookings = new List<Booking>()
                {
                    new Booking(){Email = "test1@test.com",Name = "test1",SeatId = 1},
                    new Booking(){Email = "test2@test.com",Name = "test2",SeatId = 2}
                }},
                new MeetUpDetail(){Date = DateTime.Today.AddDays(7)}
            };
        }

        private static List<Seat> GetSeats()
        {
            var seats = new List<Seat>();
            for (var row = 0; row < 10; row++)
            {
                for (var number = 1; number <= 10; number++)
                {
                  
                    seats.Add(new Seat(){SeatNumber = number, Row = ((char)(row + 65)).ToString()});
                }
            }

            return seats;
        }
    }
}
