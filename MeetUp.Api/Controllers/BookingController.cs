using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMeetUpService meetUpService, 
                                                                                IMapper mapper)
        {
            _bookingService = bookingService;
            _meetUpService = meetUpService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]List<CreateBookingDto> createBookings)
        {

            if (ModelState.IsValid)
            {
                var bookings = _mapper.Map<List<Booking>>(createBookings);
                              
                await _bookingService.CreateBookingAsync(bookings);
                return Ok();
              
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpGet("BookingByMeetUp/{meetUpId}")]
        public async Task<ActionResult> BookingByMeetUp(int meetUpId)
        {
            var meetUp = await _meetUpService.GetMeetUpAsync(meetUpId);

            if (meetUp == null) return NotFound();

            var dto = _mapper.Map<List<BookingDto>>(meetUp.Bookings);

            return Ok(dto);
        }
    }
}