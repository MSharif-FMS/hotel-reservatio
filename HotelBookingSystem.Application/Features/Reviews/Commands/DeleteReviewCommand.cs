csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}