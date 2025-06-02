csharp
using MediatR;
using System.Collections.Generic;
using HotelBookingSystem.Application.DTOs.Service; // Assuming ServiceDto is in this namespace

namespace HotelBookingSystem.Application.Features.Services.Queries.GetAllServices
{
    public class GetAllServicesQuery : IRequest<IEnumerable<ServiceDto>>
    {
        // No properties needed for getting all services
    }
}