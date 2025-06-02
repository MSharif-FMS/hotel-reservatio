csharp
using FluentValidation;
using HotelBookingSystem.Application.Features.Images.Queries.GetImagesByEntity;

namespace HotelBookingSystem.Application.Features.Images.Queries
{
    public class GetImagesByEntityQueryValidator : AbstractValidator<GetImagesByEntityQuery>
    {
        public GetImagesByEntityQueryValidator()
        {
            RuleFor(x => x.EntityType)
                .NotEmpty().WithMessage("Entity type is required.")
                .Must(BeAValidEntityType).WithMessage("Invalid entity type specified.");

            RuleFor(x => x.EntityId)
                .GreaterThan(0).WithMessage("Entity ID must be greater than 0.");
        }

        private bool BeAValidEntityType(string entityType)
        {
            if (string.IsNullOrWhiteSpace(entityType))
            {
                return false;
            }

            var lowerEntityType = entityType.ToLower();
            return lowerEntityType == "hotel" ||
                   lowerEntityType == "room_type" ||
                   lowerEntityType == "facility" ||
                   lowerEntityType == "service";
        }
    }
}