csharp
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HotelBookingSystem.Application.Features.Promotions.Commands;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Features.Promotions.Handlers
{
    public class CreatePromotionCommandHandler : IRequestHandler<CreatePromotionCommand, long>
    {
        private readonly IPromotionRepository _promotionRepository;

        public CreatePromotionCommandHandler(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public async Task<long> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotion = new Promotion
            {
                Code = request.Code,
                Name = request.Name,
                Description = request.Description,
                DiscountType = request.DiscountType,
                DiscountValue = request.DiscountValue,
                ValidFrom = request.ValidFrom,
                ValidTo = request.ValidTo,
                MinStay = request.MinStay,
                MinAmount = request.MinAmount,
                ApplicableRoomTypes = request.ApplicableRoomTypes,
                BlackoutDates = request.BlackoutDates,
                UsageLimit = request.UsageLimit,
                IsActive = request.IsActive,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };

            await _promotionRepository.AddAsync(promotion);

            return promotion.Id;
        }
    }
}