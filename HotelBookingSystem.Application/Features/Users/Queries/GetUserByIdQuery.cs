csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Users.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto> // Assuming UserDto will be created
    {
        public long Id { get; set; }

        public GetUserByIdQuery(long id)
        {
            Id = id;
        }
    }
}