using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetUp.Api.DTO;
using MeetUp.Api.DTO.Booking;
using MeetUp.Data.models;
using MeetUp.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeetUp.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IMeetUpService _meetUpService;

        public BookingController(IBookingService bookingService, IMeetUpService meetUpService)
        {
            _bookingService = bookingService;
            _meetUpService = meetUpService;
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
                }).ToList();
                              
                await _bookingService.CreateBookingAsync(bookings);
                return Ok();
              
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpGet]
        [Route("/BookingByMeetUp/{id}")]
        public async Task<ActionResult> BookingByMeetUp(int id)
        {
            var meetUp = await _meetUpService.GetMeetUpAsync(id);

            if (meetUp == null) return NotFound();
            
            var dto = meetUp.Bookings.Select(x => new BookingDto()
            {
                Email = x.Email,
                Name = x.Name,
                MeetUpId = x.MeetUpId,
                Seat = new SeatDto()
                {
                    Row = x.Seat.Row,
                    SeatNumber = x.Seat.SeatNumber

                }
            });

            return Ok(dto);
        }
    }
}