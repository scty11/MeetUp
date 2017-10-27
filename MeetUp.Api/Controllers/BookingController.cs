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
                }).ToList();

                try
                {
                   await _bookingService.CreateBookingAsync(bookings);
                    return Ok();
                }
                catch (Exception ex)
                {
                    //_Logger.LogError(exp.Message);
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
              
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
            try
            {
                var meetUp = await _bookingService.GetMeetUpAsync(id);

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
            catch (Exception exp)
            {
                //_Logger.LogError(exp.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}