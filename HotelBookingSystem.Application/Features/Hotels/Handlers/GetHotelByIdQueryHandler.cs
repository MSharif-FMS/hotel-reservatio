csharp
using MediatR;
using HotelBookingSystem.Application.Features.Hotels.Queries;
using HotelBookingSystem.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using HotelBookingSystem.Application.DTOs.Hotel;

namespace HotelBookingSystem.Application.Features.Hotels.Handlers
{
    public class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQuery, HotelDto>
    {
        private readonly IHotelRepository _hotelRepository;

        public GetHotelByIdQueryHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<HotelDto> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
        {
            var hotel = await _hotelRepository.GetByIdAsync(request.Id);

            if (hotel == null)
            {
                return null; // Or throw a custom not found exception
            }

            // Map Hotel entity to HotelDto
            var hotelDto = new HotelDto
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Location = hotel.Location,
                Address = hotel.Address, // Assuming Address is a string or complex object that can be directly assigned
                Description = hotel.Description,
                Rating = hotel.Rating,
                StarRating = hotel.StarRating,
                CheckInTime = hotel.CheckInTime,
                CheckOutTime = hotel.CheckOutTime,
                ContactEmail = hotel.ContactEmail,
                ContactPhone = hotel.ContactPhone,
                IsActive = hotel.IsActive
            };

            return hotelDto;
        }
    }
}