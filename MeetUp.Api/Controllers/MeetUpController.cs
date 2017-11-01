using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MeetUp.Api.DTO;
using MeetUp.Api.Models;
using MeetUp.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeetUp.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MeetUpController : Controller
    {
        private readonly IMeetUpService _meetUpService;
        private readonly IMapper _mapper;

        public MeetUpController(IMeetUpService meetUpService, IMapper mapper)
        {
            _meetUpService = meetUpService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> MeetUps()
        {
            var meetUps = await _meetUpService.GetMeetUpsAsync();

            var dto = _mapper.Map<List<MeetUpDto>>(meetUps);

            return Ok(dto);
        }

        [HttpGet("{meetUpId}/AvailableSeats")]
        public async Task<ActionResult> AvailableSeats(int meetUpId)
        {
           
            var meetUp = await _meetUpService.GetMeetUpAsync(meetUpId);

            if (meetUp == null) return NotFound();

            var seats = await _meetUpService.GetAvailableSeatsAsync(meetUpId);

            var dto = _mapper.Map<List<SeatDto>>(seats);

            return Ok(dto);        
        }

        [HttpGet("{meetUpId}/AvailableSeatsPage/{skip}/{take}")]
        public async Task<ActionResult> AvailableSeatsPage(int meetUpId, int skip, int take)
        {

            var meetUp = await _meetUpService.GetMeetUpAsync(meetUpId);

            if (meetUp == null) return NotFound();

            var seats = await _meetUpService.GetAvailableSeatsPageAsync(meetUpId, skip, take);

            var paging = new PagingResult<SeatDto>()
            {
                Records = _mapper.Map<List<SeatDto>>(seats),
                TotalRecords = seats.Count()
            };
            Response.Headers.Add("X-InlineCount", paging.TotalRecords.ToString());
            return Ok(paging.Records);
        }

    }
}