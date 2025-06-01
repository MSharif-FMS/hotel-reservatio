csharp
namespace HotelBookingSystem.Application.Features.CancellationPolicies.Queries
{
    using MediatR;

    public class GetCancellationPolicyByIdQuery : IRequest<CancellationPolicyDto>
    {
        public GetCancellationPolicyByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}