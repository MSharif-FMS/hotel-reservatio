csharp
using HotelBookingSystem.Application.Features.Images.Commands;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Images.Handlers
{
    public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, long>
    {
        private readonly IImageRepository _imageRepository;

        public CreateImageCommandHandler(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<long> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
            var image = new Image
            {
                EntityType = request.EntityType,
                EntityId = request.EntityId,
                ImageUrl = request.ImageUrl,
                Caption = request.Caption,
                IsPrimary = request.IsPrimary,
                SortOrder = request.SortOrder
            };

            await _imageRepository.AddAsync(image);

            return image.Id;
        }
    }
}