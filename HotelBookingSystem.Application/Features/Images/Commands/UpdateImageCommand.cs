csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Images.Commands
{
    public class UpdateImageCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public string? Caption { get; set; }
        public bool? IsPrimary { get; set; }
        public int? SortOrder { get; set; }
    }
}