csharp
using MediatR;
using System;

namespace HotelBookingSystem.Application.Features.Refunds.Commands
{
    public class UpdateRefundCommand : IRequest<Unit>
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public string? Reason { get; set; }
        public long? ProcessedBy { get; set; }
        public string Status { get; set; }
    }
}