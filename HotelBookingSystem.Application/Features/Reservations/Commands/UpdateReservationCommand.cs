csharp
using MediatR;
using System;

namespace HotelBookingSystem.Application.Features.Reservations.Commands
{
    public class UpdateReservationCommand : IRequest<Unit>
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string Status { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public string SpecialRequests { get; set; }
        public string PromoCode { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string Currency { get; set; }
        public string Source { get; set; }
        public string IpAddress { get; set; }
    }
}