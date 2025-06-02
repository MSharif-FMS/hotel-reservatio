csharp
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Application.Features.Reviews.Commands.CreateReview;

namespace HotelBookingSystem.Application.Features.Reviews.Handlers
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, long>
    {
        private readonly IReviewRepository _reviewRepository;

        public CreateReviewCommandHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<long> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review
            {
                HotelId = request.HotelId,
                UserId = request.UserId,
                ReservationId = request.ReservationId,
                Rating = request.Rating,
                Cleanliness = request.Cleanliness,
                Comfort = request.Comfort,
                Location = request.Location,
                Service = request.Service,
                Comment = request.Comment
                // CreatedAt and UpdatedAt will be set in the Infrastructure layer or entity constructor
                // IsApproved might have a default value or be set based on business rules
            };

            // Assuming AddAsync handles saving to the database and setting the ID
            await _reviewRepository.AddAsync(review);

            return review.Id;
        }
    }
}