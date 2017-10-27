using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetUp.Api.DTO;
using MeetUp.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetUp.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MeetUpController : Controller
    {
        private readonly IBookingService _bookingService;

        public MeetUpController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IActionResult> MeetUps()
        {
            try
            {
                var meetUps = await _bookingService.GetMeetUpsAsync();

                return Ok(meetUps.Select(x =>  new MeatUpDto()
                {
                    MeetUpDate = x.Date,
                    Id = x.Id
                    
                }));
            }
            catch (Exception exp)
            {
                //_Logger.LogError(exp.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> MeetUps(int id)
        {
            try
            {
                var meetUp = await _bookingService.GetMeetUpAsync(id);

                if (meetUp == null) return NotFound();

                var seats = await _bookingService.GetavailableSeatsAsync(id);

                var dto = new MeetUpAvailabilityDto()
                {
                    Date = meetUp.Date,
                    AvailableSeats = seats.Select(x => new SeatDto()
                    {
                        Row = x.Row,
                        SeatNumber = x.SeatNumber

                    }).ToList()
                };

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