csharp
using HotelBookingSystem.Application.DTOs;
using HotelBookingSystem.Application.Features.Hotels.Queries;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace HotelBookingSystem.Application.Features.Hotels.Handlers
{
    public class GetAllHotelsQueryHandler : IRequestHandler<GetAllHotelsQuery, IEnumerable<HotelDto>>
    {
        private readonly IHotelRepository _hotelRepository;

        public GetAllHotelsQueryHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<IEnumerable<HotelDto>> Handle(GetAllHotelsQuery request, CancellationToken cancellationToken)
        {
            var hotels = await _hotelRepository.GetAllAsync();
            

            // In a real application, you would use a mapping library like AutoMapper
            var hotelDtos = hotels.Select(h => new HotelDto
            {
                Id = h.Id,
                Name = h.Name,
                Location = h.Location,
                Address = h.Address, // Assuming Address is a string or simple object for now
                Rating = h.Rating,
                StarRating = h.StarRating,
                ContactEmail = h.ContactEmail,
                
                ContactPhone = h.ContactPhone
            }).ToList();

            return hotelDtos;
        }
    }
}