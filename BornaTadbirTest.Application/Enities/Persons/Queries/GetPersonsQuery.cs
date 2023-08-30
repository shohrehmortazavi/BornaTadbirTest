using AutoMapper;
using BornaTadbirTest.Application.Entities.Persons.Dtos;
using BornaTadbirTest.Domain.Shared.Interfaces;
using MediatR;

namespace BornaTadbirTest.Application.Entities.Persons.Queries
{
    public record GetPersonsQuery : IRequest<List<PersonResponseDto>>;

    public class GetPersonsQueryHandler : BaseService, IRequestHandler<GetPersonsQuery, List<PersonResponseDto>>
    {
        public GetPersonsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<List<PersonResponseDto>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            var persons = await _unitOfWork.PersonReadRepository.GetAllAsynce();

            if (!persons.Any())
                return null;

            return persons.Select(x => _mapper.Map<PersonResponseDto>(x)).ToList();
        }
    }

}
