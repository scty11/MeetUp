using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using MeetUp.Api.DTO.Booking;
using MeetUp.Services.ServiceInterfaces;

namespace MeetUp.Api.Validation.Booking
{
    public class CreatBookingListValidator : AbstractValidator<List<CreateBookingDto>>
    {
        private readonly IBookingService _bookingService;
        public CreatBookingListValidator(IBookingService bookingService)
        {
            RuleFor(x => x).NotEmpty()
                .Must(x => x.Count <= 4).WithMessage("You can only book 4 slots at a time")
                .Must(CheckBookingNameAndEmail).WithMessage("Please ensure all emails and names are unique")
                .Must(CheckAreIndividulaSeats).WithMessage("You cannot book the same seat")
                .SetCollectionValidator(new CreateBookingDtoValidator(bookingService));
            
        }

        private bool CheckAreIndividulaSeats(List<CreateBookingDto> arg)
        {
            var seats = arg.Select(x => x.SeatId);

            return seats.Count() == new HashSet<int>(seats).Count();
        }

        private bool CheckBookingNameAndEmail(List<CreateBookingDto> arg)
        {
            var emails = arg.Select(x => x.Email);

            var names = arg.Select(x => x.Name);

            return emails.Count() == new HashSet<string>(emails).Count()
                  && names.Count() == new HashSet<string>(names).Count();
        }
    }
}
