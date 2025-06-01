csharp
using MediatR;
using HotelBookingSystem.Application.Features.Hotels.Commands;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace HotelBookingSystem.Application.Features.Hotels.Handlers
{
    public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, long>
    {
        private readonly IHotelRepository _hotelRepository;

        public CreateHotelCommandHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<long> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = new Hotel
            {
                Name = request.Name,
                Location = request.Location,
                Address = request.Address, // Assuming Address is handled as a string for now
                Description = request.Description, 
                Rating = request.Rating,
                StarRating = request.StarRating,
                CheckInTime = request.CheckInTime,
                CheckOutTime = request.CheckOutTime,
                ContactEmail = request.ContactEmail,
                ContactPhone = request.ContactPhone,
                IsActive = true, // Default to active on creation
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };

            await _hotelRepository.AddAsync(hotel);

            return hotel.Id;
        }
    }
}