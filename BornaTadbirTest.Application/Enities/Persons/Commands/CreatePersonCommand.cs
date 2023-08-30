using AutoMapper;
using BornaTadbirTest.Application.Entities.Persons.Dtos;
using BornaTadbirTest.Domain.Entities.Persons;
using BornaTadbirTest.Domain.Shared.Interfaces;
using MediatR;

namespace BornaTadbirTest.Application.Entities.Persons.Commands
{
    public record CreatePersonCommand(PersonRequestDto PersonRequest) : IRequest<PersonResponseDto>;

    public class CreatePersonCommandHandler : BaseService, IRequestHandler<CreatePersonCommand, PersonResponseDto>
    {
        public CreatePersonCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<PersonResponseDto> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var newPerson = Person.Create(request.PersonRequest.Name, request.PersonRequest.Family);

            var result = await _unitOfWork.PersonWriteRepository.AddAsync(newPerson);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<PersonResponseDto>(result);
        }
    }
}
