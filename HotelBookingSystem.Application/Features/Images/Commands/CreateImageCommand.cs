csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Images.Commands
{
    public class CreateImageCommand : IRequest<long>
    {
        public string EntityType { get; set; }
        public long EntityId { get; set; }
        public string ImageUrl { get; set; }
        public string? Caption { get; set; }
        public bool IsPrimary { get; set; }
        public int SortOrder { get; set; }
    }
}