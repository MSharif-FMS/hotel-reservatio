csharp
using AutoMapper;
using HotelBookingSystem.Application.Features.Promotions.Queries.GetAllPromotions;
using HotelBookingSystem.Application.Features.Promotions.Queries;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Promotions.Handlers
{
    public class GetAllPromotionsQueryHandler : IRequestHandler<GetAllPromotionsQuery, IEnumerable<PromotionDto>>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;

        public GetAllPromotionsQueryHandler(IPromotionRepository promotionRepository, IMapper mapper)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PromotionDto>> Handle(GetAllPromotionsQuery request, CancellationToken cancellationToken)
        {
            var promotions = await _promotionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PromotionDto>>(promotions);
        }
    }
}