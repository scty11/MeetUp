using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MeetUp.Api.DTO.Booking;
using MeetUp.Services.ServiceInterfaces;

namespace MeetUp.Api.Validation.Booking
{
    public class CreateBookingDtoValidator : AbstractValidator<CreateBookingDto>
    {
        private readonly IBookingService _bookingService;

        public CreateBookingDtoValidator(IBookingService bookingService)
        {
            _bookingService = bookingService;

            RuleFor(reg => reg.MeetUpId).NotEmpty()
                      .MustAsync(CheckAvailability)
                      .WithMessage("The seat is not available"); 
            RuleFor(reg => reg.SeatId).NotEmpty();
            RuleFor(reg => reg.Name).NotEmpty()
                .MustAsync(ValidateUniqueName)
                .WithMessage("Name is already present on a booking");
            RuleFor(reg => reg.Email).NotEmpty().EmailAddress()
                .MustAsync(ValidateUniqueEmail)
                .WithMessage("Email is already present on a booking");
        }

        private async Task<bool> CheckAvailability(CreateBookingDto args, int meetUpId, CancellationToken arg2)
        {
            var bookings = await _bookingService.GetBookingByMeetUpIdAsync(meetUpId);
            return !bookings.Any(x => x.SeatId == args.SeatId);
        }

        public async Task<bool> ValidateUniqueEmail(CreateBookingDto args, string email,
            CancellationToken cancellationToken)
        {
            return await _bookingService.CkeckEmailIsUniqueAsync(email, args.MeetUpId);
        }

        public async Task<bool> ValidateUniqueName(CreateBookingDto args, string name,
            CancellationToken cancellationToken)
        {
            return await _bookingService.CkeckNameIsUniqueAsync(name, args.MeetUpId);
        }
    }
}
