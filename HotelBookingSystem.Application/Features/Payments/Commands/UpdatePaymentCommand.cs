csharp
using MediatR;
using System;

namespace HotelBookingSystem.Application.Features.Payments.Commands
{
    public class UpdatePaymentCommand : IRequest<Unit>
    {
        public long Id { get; set; }
        public string? Status { get; set; }
        public string? ReceiptUrl { get; set; }
    }
}