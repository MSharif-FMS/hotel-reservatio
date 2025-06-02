csharp
using AutoMapper;
using HotelBookingSystem.Application.Features.Promotions.Queries.GetPromotionByCode;
using HotelBookingSystem.Application.Features.Promotions.Queries;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Promotions.Handlers
{
    public class GetPromotionByCodeQueryHandler : IRequestHandler<GetPromotionByCodeQuery, PromotionDto>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;

        public GetPromotionByCodeQueryHandler(IPromotionRepository promotionRepository, IMapper mapper)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }

        public async Task<PromotionDto> Handle(GetPromotionByCodeQuery request, CancellationToken cancellationToken)
        {
            var promotion = await _promotionRepository.GetByCodeAsync(request.Code);

            if (promotion == null)
            {
                return null;
            }

            return _mapper.Map<PromotionDto>(promotion);
        }
    }
}