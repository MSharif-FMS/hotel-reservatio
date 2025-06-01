csharp
using MediatR;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.CancellationPolicies.Queries
{
 public class GetAllCancellationPoliciesQuery : IRequest<IEnumerable<CancellationPolicyDto>>
    {
    }
}