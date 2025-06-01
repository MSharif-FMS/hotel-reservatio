csharp
using MediatR;
using System.Collections.Generic;
using HotelBookingSystem.Application.Features.Reservations.Queries;

namespace HotelBookingSystem.Application.Features.Reservations.Queries
{
    public class GetAllReservationsQuery : IRequest<List<ReservationDto>>
    {
        // Optional properties for filtering or pagination
        // public int PageNumber { get; set; }
        // public int PageSize { get; set; }
        // public string Status { get; set; }
    }
}