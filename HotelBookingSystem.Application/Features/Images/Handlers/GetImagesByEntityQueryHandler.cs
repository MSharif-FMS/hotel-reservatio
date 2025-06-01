csharp
using HotelBookingSystem.Application.Features.Images.Queries;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Images.Handlers
{
    public class GetImagesByEntityQueryHandler : IRequestHandler<GetImagesByEntityQuery, IEnumerable<ImageDto>>
    {
        private readonly IImageRepository _imageRepository;

        public GetImagesByEntityQueryHandler(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<IEnumerable<ImageDto>> Handle(GetImagesByEntityQuery request, CancellationToken cancellationToken)
        {
            // This is a placeholder implementation.
            // You will need to implement the actual logic to retrieve images
            // from the repository based on entity type and ID and map them to ImageDto.
            var images = await _imageRepository.GetImagesByEntityTypeAndIdAsync(request.EntityType, request.EntityId);

            // Assuming you have a way to map Image entities to ImageDto
            var imageDtos = images.Select(image => new ImageDto
            {
                Id = image.Id,
                EntityType = image.EntityType,
                EntityId = image.EntityId,
                ImageUrl = image.ImageUrl,
                Caption = image.Caption,
                IsPrimary = image.IsPrimary,
                SortOrder = image.SortOrder
            }).ToList();

            return imageDtos;
        }
    }
}