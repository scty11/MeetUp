﻿using System.Linq;
using System.Threading.Tasks;
using MeetUp.Api.DTO;
using MeetUp.Api.DTO.MeetUp;
using MeetUp.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeetUp.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MeetUpController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IMeetUpService _meetUpService;

        public MeetUpController(IBookingService bookingService, IMeetUpService meetUpService)
        {
            _bookingService = bookingService;
            _meetUpService = meetUpService;
        }

        [HttpGet]
        public async Task<IActionResult> MeetUps()
        {
            var meetUps = await _meetUpService.GetMeetUpsAsync();

            return Ok(meetUps.Select(x =>  new MeatUpDto()
            {
                MeetUpDate = x.Date,
                Id = x.Id
                
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> MeetUps(int id)
        {
           
            var meetUp = await _meetUpService.GetMeetUpAsync(id);

            if (meetUp == null) return NotFound();

            var seats = await _meetUpService.GetavailableSeatsAsync(id);

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

    }
}