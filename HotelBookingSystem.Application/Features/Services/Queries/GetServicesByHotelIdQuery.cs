csharp
using MediatR;
using System.Collections.Generic;
using HotelBookingSystem.Application.DTOs.Service; // Assuming ServiceDto is in this namespace

namespace HotelBookingSystem.Application.Features.Services.Queries.GetServicesByHotelId
{
    public class GetServicesByHotelIdQuery : IRequest<IEnumerable<ServiceDto>>
    {
        public long HotelId { get; set; }
    }
}