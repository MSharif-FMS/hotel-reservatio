csharp
using AutoMapper;
using HotelBookingSystem.Application.Features.Promotions.Queries.GetActivePromotions;
using HotelBookingSystem.Application.Features.Promotions.Queries.PromotionDto;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Promotions.Handlers
{
    public class GetActivePromotionsQueryHandler : IRequestHandler<GetActivePromotionsQuery, IEnumerable<PromotionDto>>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;

        public GetActivePromotionsQueryHandler(IPromotionRepository promotionRepository, IMapper mapper)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PromotionDto>> Handle(GetActivePromotionsQuery request, CancellationToken cancellationToken)
        {
            var activePromotions = await _promotionRepository.GetActiveAsync(); // Assuming GetActiveAsync method exists in the repository
            return _mapper.Map<IEnumerable<PromotionDto>>(activePromotions);
        }
    }
}