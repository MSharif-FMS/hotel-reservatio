csharp
using HotelBookingSystem.Application.Features.Images.Commands;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Images.Handlers
{
    public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand, bool>
    {
        private readonly IImageRepository _imageRepository;

        public DeleteImageCommandHandler(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<bool> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            var image = await _imageRepository.GetByIdAsync(request.Id);

            if (image == null)
            {
                return false; // Image not found
            }

            await _imageRepository.DeleteAsync(image);

            // Assuming SaveChangesAsync is called as part of a Unit of Work or in the repository implementation
            // You might need to explicitly call a SaveChanges method here depending on your repository pattern
            // For simplicity, assuming the repository handles saving.

            return true;
        }
    }
}