using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetUp.Data.models;
using MeetUp.Repositories.IRepositories;
using MeetUp.Services.ServiceInterfaces;

namespace MeetUp.Services
{
    public class MeetUpService : IMeetUpService
    {
        private readonly IMeetUpRepository _meetUpRepository;
        private readonly ISeatRepository _seatRepository;

        public MeetUpService(IMeetUpRepository meetUpRepository, ISeatRepository seatRepository)
        {
            _meetUpRepository = meetUpRepository;
            _seatRepository = seatRepository;
        }

        public async Task<List<MeetUpDetail>> GetMeetUpsAsync()
        {
            return await _meetUpRepository.GetMeetUpsAsync();
        }

        public async Task<List<Seat>> GetSeatsAsync()
        {
            return await _seatRepository.GetSeatsAsync();
        }

        public async Task<List<Seat>> GetAvailableSeatsAsync(int id)
        {
            var bookedSeatsIds = new List<int>();
            var bookedSeats = new List<Seat>();

            var meetUp = await _meetUpRepository.GetMeetUpWithBookingsAsync(id);

            if (meetUp == null) return bookedSeats;

            bookedSeatsIds = meetUp.Bookings.Select(x => x.Seat.Id).ToList();
            bookedSeats = await _seatRepository.GetSeatsByIdsAsync(bookedSeatsIds);

            return bookedSeats;
        }

        public async Task<MeetUpDetail> GetMeetUpAsync(int id)
        {
            return await _meetUpRepository.GetMeetUpWithBookingsAsync(id);
        }


        public async Task<List<Seat>> GetAvailableSeatsPageAsync(int meetUpId, int skip, int take)
        {
            var bookedSeatsIds = new List<int>();
            var bookedSeats = new List<Seat>();

            var meetUp = await _meetUpRepository.GetMeetUpWithBookingsAsync(meetUpId);

            if (meetUp == null) return bookedSeats;

            bookedSeatsIds = meetUp.Bookings.Select(x => x.Seat.Id).ToList();
            bookedSeats = await _seatRepository.GetSeatsByIdsPageAsync(bookedSeatsIds,skip,take);

            return bookedSeats;
        }
    }
}
