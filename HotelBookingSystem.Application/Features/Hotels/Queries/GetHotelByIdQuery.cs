csharp
using MediatR;
using HotelBookingSystem.Application.DTOs.Hotels;

namespace HotelBookingSystem.Application.Features.Hotels.Queries
{
    public class GetHotelByIdQuery : IRequest<HotelDto>
    {
        public long HotelId { get; set; }
    }
}