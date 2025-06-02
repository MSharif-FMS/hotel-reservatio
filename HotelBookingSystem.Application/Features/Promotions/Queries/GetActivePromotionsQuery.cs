csharp
using MediatR;
using System.Collections.Generic;
using HotelBookingSystem.Application.Features.Promotions.Queries; // Adjust the namespace if needed

namespace HotelBookingSystem.Application.Features.Promotions.Queries
{
    public class GetActivePromotionsQuery : IRequest<IEnumerable<PromotionDto>>
    {
        // No specific properties needed for this query
    }
}