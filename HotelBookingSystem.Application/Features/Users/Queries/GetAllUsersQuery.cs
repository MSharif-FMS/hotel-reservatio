csharp
using MediatR;
using HotelBookingSystem.Application.DTOs;

namespace HotelBookingSystem.Application.Features.Users.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
    {
        // No properties needed for this query
    }
}