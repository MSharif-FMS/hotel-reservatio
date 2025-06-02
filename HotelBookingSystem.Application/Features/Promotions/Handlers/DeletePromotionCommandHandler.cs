csharp
using MediatR;
using HotelBookingSystem.Application.Features.Promotions.Commands;
using HotelBookingSystem.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Promotions.Handlers
{
    public class DeletePromotionCommandHandler : IRequestHandler<DeletePromotionCommand, bool>
    {
        private readonly IPromotionRepository _promotionRepository;

        public DeletePromotionCommandHandler(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public async Task<bool> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the promotion to delete
            var promotion = await _promotionRepository.GetByIdAsync(request.Id);

            if (promotion == null)
            {
                // Promotion not found
                return false;
            }

            // Delete the promotion
            await _promotionRepository.DeleteAsync(promotion);

            // In a real application, you would also likely commit the transaction/save changes here
            // await _unitOfWork.SaveChangesAsync();

            return true; // Indicate successful deletion
        }
    }
}