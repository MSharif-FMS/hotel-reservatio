csharp
using MediatR;
using System;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.Promotions.Commands
{
    public class CreatePromotionCommand : IRequest<long>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        public DateTimeOffset ValidFrom { get; set; }
        public DateTimeOffset ValidTo { get; set; }
        public int? MinStay { get; set; }
        public decimal? MinAmount { get; set; }
        public List<long>? ApplicableRoomTypes { get; set; } // Using List<long> for bigint[]
        public List<DateOnly>? BlackoutDates { get; set; } // Using List<DateOnly> for date[]
        public int? UsageLimit { get; set; }
        public bool IsActive { get; set; }
    }
}