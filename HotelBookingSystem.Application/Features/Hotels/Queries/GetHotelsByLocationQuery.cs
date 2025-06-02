csharp
using MediatR;
using System.Collections.Generic;
using HotelBookingSystem.Application.DTOs.Hotel;

namespace HotelBookingSystem.Application.Features.Hotels.Queries.GetHotelsByLocation
{
    public class GetHotelsByLocationQuery : IRequest<IEnumerable<HotelDto>>
    {
        public string Location { get; set; }
    }
}