using AutoMapper;
using BornaTadbirTest.Application.Enities.BuyTransactions.Dtos;
using BornaTadbirTest.Domain.Shared.Interfaces;
using MediatR;

namespace BornaTadbirTest.Application.Entities.BuyTransactions.Queries
{
    public record GetMaxBuyerInDateQuery(BuyerPersonRequestDto BuyerPersonRequest) : IRequest<BuyerPersonResponseDto>;

    public class GetMaxBuyerInDateQueryHandler : BaseService, IRequestHandler<GetMaxBuyerInDateQuery, BuyerPersonResponseDto>
    {
        public GetMaxBuyerInDateQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<BuyerPersonResponseDto> Handle(GetMaxBuyerInDateQuery request, CancellationToken cancellationToken)
        {
            var buyTransactions = await _unitOfWork.BuyTransactionReadRepository
                .Find(x => x.CreatedDate <= request.BuyerPersonRequest.EndDate &&
                         x.CreatedDate > request.BuyerPersonRequest.StartDate);

            if (!buyTransactions.Any())
                return null;

            var maxBuyerPerson = buyTransactions.GroupBy(x => x.PersonId).Select(g => new BuyerPersonResponseDto
            {
                Id = g.Key,
                TotalPrice = g.Sum(x => x.Price)
            }).OrderByDescending(x => x.TotalPrice).FirstOrDefault();

            if (maxBuyerPerson == null)
                return null;

            var person = _unitOfWork.PersonReadRepository.Find(x => x.Id == maxBuyerPerson.Id).Result.FirstOrDefault();
            if (person != null)
            {
                maxBuyerPerson.Name = person.Name;
                maxBuyerPerson.Family = person.Family;
            }

            return maxBuyerPerson;
        }
    }

}
