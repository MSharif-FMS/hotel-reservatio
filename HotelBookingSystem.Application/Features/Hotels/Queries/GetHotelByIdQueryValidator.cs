csharp
using FluentValidation;
using HotelBookingSystem.Application.Features.Hotels.Queries.GetHotelById;

namespace HotelBookingSystem.Application.Features.Hotels.Queries
{
    public class GetHotelByIdQueryValidator : AbstractValidator<GetHotelByIdQuery>
    {
        public GetHotelByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Hotel ID must be greater than 0.");
        }
    }
}