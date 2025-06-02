csharp
using MediatR;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Reviews.Handlers
{
    public class UpdateReviewCommandHandler : IRequestHandler<Commands.UpdateReviewCommand, bool>
    {
        private readonly IReviewRepository _reviewRepository;

        public UpdateReviewCommandHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<bool> Handle(Commands.UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.GetByIdAsync(request.Id);

            if (review == null)
            {
                return false; // Review not found
            }

            // Update review properties from the command
            review.Rating = request.Rating;
            review.Cleanliness = request.Cleanliness;
            review.Comfort = request.Comfort;
            review.Location = request.Location;
            review.Service = request.Service;
            review.Comment = request.Comment;
            review.UpdatedAt = DateTimeOffset.UtcNow; // Update the UpdatedAt timestamp

            // Assuming UpdateAsync handles saving changes
            return await _reviewRepository.UpdateAsync(review);
        }
    }
}