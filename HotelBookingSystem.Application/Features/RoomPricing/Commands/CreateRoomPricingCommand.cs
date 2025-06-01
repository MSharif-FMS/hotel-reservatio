csharp
using MediatR;
using System;

namespace HotelBookingSystem.Application.Features.RoomPricing.Commands
{
    public class CreateRoomPricingCommand : IRequest<long>
    {
        // Include properties for room pricing creation data.
        // For example:
        // public long RoomTypeId { get; set; }
        // public long RatePlanId { get; set; }
        // public DateTime Date { get; set; }
        // public decimal Price { get; set; }
    }
}