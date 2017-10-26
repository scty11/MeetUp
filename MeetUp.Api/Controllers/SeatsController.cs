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
    public class SeatsController : Controller
    {
        private readonly IBookingService _bookingService;

        public SeatsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IActionResult> Seats()
        {
            try
            {
                var seats = await _bookingService.GetSeatsAsync();
                return Ok(seats);
            }
            catch (Exception exp)
            {
                //_Logger.LogError(exp.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}