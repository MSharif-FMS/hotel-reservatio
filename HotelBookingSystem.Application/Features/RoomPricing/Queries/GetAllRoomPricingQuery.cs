csharp
using MediatR;
using HotelBookingSystem.Application.DTOs;

namespace HotelBookingSystem.Application.Features.RoomPricing.Queries
{
 public class GetAllRoomPricingQuery : IRequest<IEnumerable<RoomPricingDto>>
    {
        // No properties needed
    }
}