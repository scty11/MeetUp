using AutoMapper;
using MeetUp.Api.DTO;
using MeetUp.Api.DTO.Booking;
using MeetUp.Data.models;

namespace MeetUp.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            CreateMap<MeetUpDetail, MeetUpDto>();
            CreateMap<Seat, SeatDto>();
            CreateMap<Booking, BookingDto>();

            //Dto to Domain
            CreateMap<CreateBookingDto, Booking>();
        }
    }
}
