using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetUp.Api.DTO;
using MeetUp.Data.models;
using MeetUp.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetUp.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]List<CreateBookingDto> createBooking)
        {
            
            if (ModelState.IsValid)
            {
                var bookings = createBooking.Select(x => new Booking()
                {
                    MeetUpId = x.MeetUpId,
                    SeatId = x.SeatId,
                    Email = x.Email,
                    Name = x.Name
                });
                _bookingService.createBooking(bookings);
                return Ok();
            }
            else
            {
                return BadRequest(createBooking);
            }
        }
    }
}