csharp
using HotelBookingSystem.Application.Features.Promotions.Queries;
using HotelBookingSystem.Application.Interfaces;
using MediatR;

namespace HotelBookingSystem.Application.Features.Promotions.Handlers
{
    public class GetPromotionsQueryHandler : IRequestHandler<GetAllPromotionsQuery, IEnumerable<PromotionDto>>
    {
        private readonly IPromotionRepository _promotionRepository;

        public GetPromotionsQueryHandler(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public async Task<IEnumerable<PromotionDto>> Handle(GetAllPromotionsQuery request, CancellationToken cancellationToken)
        {
            var promotions = await _promotionRepository.GetAllAsync(); // Assuming GetAllAsync exists

            // Map promotions to PromotionDto (You'll need a mapping library like AutoMapper or manual mapping)
            var promotionDtos = promotions.Select(p => new PromotionDto
            {
                Id = p.Id,
                Code = p.Code,
                Name = p.Name,
                Description = p.Description,
                DiscountType = p.DiscountType,
                DiscountValue = p.DiscountValue,
                ValidFrom = p.ValidFrom,
                ValidTo = p.ValidTo,
                MinStay = p.MinStay,
                MinAmount = p.MinAmount,
                ApplicableRoomTypes = p.ApplicableRoomTypes,
                BlackoutDates = p.BlackoutDates,
                UsageLimit = p.UsageLimit,
                TimesUsed = p.TimesUsed,
                IsActive = p.IsActive,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            });

            return promotionDtos;
        }
    }
}