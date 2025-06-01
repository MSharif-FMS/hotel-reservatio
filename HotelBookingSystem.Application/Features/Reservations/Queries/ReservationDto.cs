csharp
using HotelBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.Reservations.Queries
{
    public class ReservationDto
    {
        public long Id { get; set; }
        public string ReservationNumber { get; set; }
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
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        // Include properties for related entities if needed, e.g.,
        // public UserDto User { get; set; }
        // public List<ReservationRoomDto> ReservationRooms { get; set; }
    }
}