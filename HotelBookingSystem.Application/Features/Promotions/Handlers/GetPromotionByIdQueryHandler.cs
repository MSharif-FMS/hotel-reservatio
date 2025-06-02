csharp
using AutoMapper;
using HotelBookingSystem.Application.Features.Promotions.Queries.GetPromotionById;
using HotelBookingSystem.Application.Features.Promotions.Queries;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Promotions.Handlers
{
    public class GetPromotionByIdQueryHandler : IRequestHandler<GetPromotionByIdQuery, PromotionDto>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;

        public GetPromotionByIdQueryHandler(IPromotionRepository promotionRepository, IMapper mapper)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }

        public async Task<PromotionDto> Handle(GetPromotionByIdQuery request, CancellationToken cancellationToken)
        {
            var promotion = await _promotionRepository.GetByIdAsync(request.Id);

            if (promotion == null)
            {
                return null;
            }

            return _mapper.Map<PromotionDto>(promotion);
        }
    }
}