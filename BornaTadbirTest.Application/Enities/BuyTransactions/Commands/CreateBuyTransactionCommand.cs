using AutoMapper;
using BornaTadbirTest.Application.Entities.BuyTransactions.Dtos;
using BornaTadbirTest.Domain.Entities.BuyTransactions;
using BornaTadbirTest.Domain.Shared.Interfaces;
using MediatR;

namespace BornaTadbirTest.Application.Entities.BuyTransactions.Commands
{
    public record CreateBuyTransactionCommand(BuyTransactionRequestDto BuyTransactionRequest) : IRequest<BuyTransactionResponseDto>;

    public class CreateBuyTransactionCommandHandler : BaseService, IRequestHandler<CreateBuyTransactionCommand, BuyTransactionResponseDto>
    {
        public CreateBuyTransactionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<BuyTransactionResponseDto> Handle(CreateBuyTransactionCommand request, CancellationToken cancellationToken)
        {
            var requested = request.BuyTransactionRequest;
            var newBuyTransaction = BuyTransaction.Create(requested.PersonId, DateTime.Now, requested.Price);

            var result = await _unitOfWork.BuyTransactionWriteRepository.AddAsync(newBuyTransaction);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<BuyTransactionResponseDto>(result);
        }
    }
}
