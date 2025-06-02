csharp
using MediatR;
using System;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.Promotions.Commands
{
    public class UpdatePromotionCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? DiscountType { get; set; }
        public decimal? DiscountValue { get; set; }
        public DateTimeOffset? ValidFrom { get; set; }
        public DateTimeOffset? ValidTo { get; set; }
        public int? MinStay { get; set; }
        public decimal? MinAmount { get; set; }
        public long[]? ApplicableRoomTypes { get; set; }
        public DateOnly[]? BlackoutDates { get; set; }
        public int? UsageLimit { get; set; }
        public bool? IsActive { get; set; }
    }
}