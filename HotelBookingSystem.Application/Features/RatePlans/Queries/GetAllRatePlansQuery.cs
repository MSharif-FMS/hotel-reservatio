csharp
using MediatR;
// using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.RatePlans.Queries;
{
 public class GetAllRatePlansQuery : IRequest<IEnumerable<RatePlanDto>>
 {
 }
}