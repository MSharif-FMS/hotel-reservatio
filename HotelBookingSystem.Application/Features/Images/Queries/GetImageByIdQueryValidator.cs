csharp
using FluentValidation;
using HotelBookingSystem.Application.Features.Images.Queries;

namespace HotelBookingSystem.Application.Features.Images.Queries
{
    public class GetImageByIdQueryValidator : AbstractValidator<GetImageByIdQuery>
    {
        public GetImageByIdQueryValidator()
        {
            RuleFor(query => query.Id)
                .GreaterThan(0).WithMessage("Image Id must be greater than 0.");
        }
    }
}