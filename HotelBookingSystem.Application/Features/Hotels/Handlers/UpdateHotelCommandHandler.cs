csharp
using HotelBookingSystem.Application.Features.Hotels.Commands;
using HotelBookingSystem.Domain.Interfaces;
using MediatR;

namespace HotelBookingSystem.Application.Features.Hotels.Handlers
{
    public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand, bool>
    {
        private readonly IHotelRepository _hotelRepository;

        public UpdateHotelCommandHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<bool> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = await _hotelRepository.GetByIdAsync(request.Id);

            if (hotel == null)
            {
                return false; // Hotel not found
            }

            // Map properties from command to entity
            hotel.Name = request.Name;
            hotel.Location = request.Location;
            hotel.Address = request.Address;
            hotel.Description = request.Description;
            hotel.Rating = request.Rating;
            hotel.StarRating = request.StarRating;
            hotel.CheckInTime = request.CheckInTime;
            hotel.CheckOutTime = request.CheckOutTime;
            hotel.ContactEmail = request.ContactEmail;
            hotel.ContactPhone = request.ContactPhone;
            hotel.IsActive = request.IsActive;
            hotel.UpdatedAt = DateTimeOffset.UtcNow; // Update timestamp

            return await _hotelRepository.UpdateAsync(hotel);
        }
    }
}