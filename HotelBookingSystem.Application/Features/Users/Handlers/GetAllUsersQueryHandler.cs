csharp
using HotelBookingSystem.Application.Features.Users.Queries;
using HotelBookingSystem.Application.DTOs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace HotelBookingSystem.Application.Features.Users.Handlers
{// Assuming IUserRepository is in the Domain.Interfaces namespace
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        private readonly Domain.Interfaces.IUserRepository _userRepository; // Specify the full namespace
        private readonly IMapper _mapper;
        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}