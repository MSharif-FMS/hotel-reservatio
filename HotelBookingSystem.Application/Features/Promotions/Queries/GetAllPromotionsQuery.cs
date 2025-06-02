csharp
using MediatR;
using System.Collections.Generic;
using HotelBookingSystem.Application.Features.Promotions.Queries; // Assuming PromotionDto is in this namespace

namespace HotelBookingSystem.Application.Features.Promotions.Queries.GetAllPromotions
{
    public class GetAllPromotionsQuery : IRequest<IEnumerable<PromotionDto>>
    {
        // No properties needed for getting all promotions
    }
}