csharp
using AutoMapper;
using HotelBookingSystem.Application.Features.Images.Queries.GetImageById;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Application.Features.Images.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Images.Handlers
{
    public class GetImageByIdQueryHandler : IRequestHandler<GetImageByIdQuery, ImageDto>
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public GetImageByIdQueryHandler(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public async Task<ImageDto> Handle(GetImageByIdQuery request, CancellationToken cancellationToken)
        {
            var image = await _imageRepository.GetByIdAsync(request.Id);

            if (image == null)
            {
                return null;
            }

            return _mapper.Map<ImageDto>(image);
        }
    }
}