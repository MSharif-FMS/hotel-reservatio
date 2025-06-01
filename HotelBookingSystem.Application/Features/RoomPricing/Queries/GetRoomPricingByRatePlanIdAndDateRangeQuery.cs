csharp
using MediatR;
using System;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.RoomPricing.Queries
{
    public class GetRoomPricingByRatePlanIdAndDateRangeQuery : IRequest<IEnumerable<RoomPricingDto>>
    {
        public long RatePlanId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}