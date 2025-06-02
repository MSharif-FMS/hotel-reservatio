csharp
using HotelBookingSystem.Application.Features.Promotions.Commands;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Promotions.Handlers
{
    public class UpdatePromotionCommandHandler : IRequestHandler<UpdatePromotionCommand, bool>
    {
        private readonly IPromotionRepository _promotionRepository;

        public UpdatePromotionCommandHandler(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public async Task<bool> Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotion = await _promotionRepository.GetByIdAsync(request.Id);

            if (promotion == null)
            {
                return false;
            }

            // Update promotion properties
            promotion.Name = request.Name;
            promotion.Description = request.Description;
            promotion.DiscountType = request.DiscountType;
            promotion.DiscountValue = request.DiscountValue;
            promotion.ValidFrom = request.ValidFrom;
            promotion.ValidTo = request.ValidTo;
            promotion.MinStay = request.MinStay;
            promotion.MinAmount = request.MinAmount;
            promotion.ApplicableRoomTypes = request.ApplicableRoomTypes;
            promotion.BlackoutDates = request.BlackoutDates;
            promotion.UsageLimit = request.UsageLimit;
            promotion.IsActive = request.IsActive;
            promotion.UpdatedAt = DateTimeOffset.UtcNow; // Update the updated time

            // Add domain events here if updating triggers any

            return await _promotionRepository.UpdateAsync(promotion);
        }
    }
}