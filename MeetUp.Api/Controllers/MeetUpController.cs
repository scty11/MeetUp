using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                return Ok(meetUps);
            }
            catch (Exception exp)
            {
                //_Logger.LogError(exp.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{date}")]
        public async Task<ActionResult> MeetUps(DateTime date)
        {
            try
            {
                var meetUp = await _bookingService.GetMeetUpAsync(date);

                return Ok(meetUp);
            }
            catch (Exception exp)
            {
                //_Logger.LogError(exp.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}