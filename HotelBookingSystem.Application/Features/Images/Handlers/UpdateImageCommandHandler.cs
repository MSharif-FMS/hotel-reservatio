csharp
using HotelBookingSystem.Application.Features.Images.Commands;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Images.Handlers
{
    public class UpdateImageCommandHandler : IRequestHandler<UpdateImageCommand, bool>
    {
        private readonly IImageRepository _imageRepository;

        public UpdateImageCommandHandler(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<bool> Handle(UpdateImageCommand request, CancellationToken cancellationToken)
        {
            var image = await _imageRepository.GetByIdAsync(request.Id);

            if (image == null)
            {
                return false;
            }

            // Update image properties based on command
            image.Caption = request.Caption;
            image.IsPrimary = request.IsPrimary;
            image.SortOrder = request.SortOrder;
            // Assuming UpdatedAt is handled by entity or context

            await _imageRepository.UpdateAsync(image);

            return true;
        }
    }
}