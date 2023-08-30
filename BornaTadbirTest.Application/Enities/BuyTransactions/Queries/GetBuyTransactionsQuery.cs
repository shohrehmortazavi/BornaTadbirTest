using AutoMapper;
using BornaTadbirTest.Application.Entities.BuyTransactions.Dtos;
using BornaTadbirTest.Domain.Entities.BuyTransactions;
using BornaTadbirTest.Domain.Shared.Interfaces;
using MediatR;

namespace BornaTadbirTest.Application.Entities.BuyTransactions.Queries
{
    public record GetBuyTransactionsQuery(int? UserId) : IRequest<List<BuyTransactionResponseDto>>;

    public class GetBuyTransactionsQueryHandler : BaseService, IRequestHandler<GetBuyTransactionsQuery, List<BuyTransactionResponseDto>>
    {
        public GetBuyTransactionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<List<BuyTransactionResponseDto>> Handle(GetBuyTransactionsQuery request, CancellationToken cancellationToken)
        {
            var buyTransactions = new List<BuyTransaction>();

            if (request.UserId != null)
                buyTransactions = await _unitOfWork.BuyTransactionReadRepository.Find(x => x.PersonId == request.UserId.Value);
            else
                buyTransactions = await _unitOfWork.BuyTransactionReadRepository.GetAllAsynce();

            if (!buyTransactions.Any())
                return null;

            return buyTransactions.Select(x => _mapper.Map<BuyTransactionResponseDto>(x)).ToList();
        }
    }

}
