csharp
using MediatR;
using System;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.RoomPricing.Queries
{
    public class GetRoomPricingByRoomTypeIdAndDateRangeQuery : IRequest<IEnumerable<RoomPricingDto>>
    {
        public long RoomTypeId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}