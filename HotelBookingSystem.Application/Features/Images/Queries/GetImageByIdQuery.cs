csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Images.Queries
{
    public class GetImageByIdQuery : IRequest<ImageDto>
    {
        public long Id { get; set; }
    }
}