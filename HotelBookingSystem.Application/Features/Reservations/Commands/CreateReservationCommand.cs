csharp
using MediatR;
using System;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.Reservations.Commands
{
    public class CreateReservationCommand : IRequest<long>
    {
        public long? UserId { get; set; }
        public DateTimeOffset CheckInDate { get; set; }
        public DateTimeOffset CheckOutDate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public string SpecialRequests { get; set; }
        public string PromoCode { get; set; }
        public string Source { get; set; }
        public string IpAddress { get; set; }

        public List<ReservationRoomDetail> RoomDetails { get; set; }

        public class ReservationRoomDetail
        {
            public long RoomTypeId { get; set; }
            public long RatePlanId { get; set; }
            public int Adults { get; set; }
            public int Children { get; set; }
            public string SpecialRequests { get; set; }
            public List<GuestDetail> Guests { get; set; }
        }

        public class GuestDetail
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string IdType { get; set; }
            public string IdNumber { get; set; }
            public string Nationality { get; set; }
            public bool IsPrimary { get; set; }
        }
    }
}