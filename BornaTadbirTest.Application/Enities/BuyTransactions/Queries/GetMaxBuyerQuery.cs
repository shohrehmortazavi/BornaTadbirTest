using AutoMapper;
using BornaTadbirTest.Application.Enities.BuyTransactions.Dtos;
using BornaTadbirTest.Domain.Shared.Interfaces;
using MediatR;

namespace BornaTadbirTest.Application.Entities.BuyTransactions.Queries
{
    public record GetMaxBuyerQuery() : IRequest<BuyerPersonResponseDto>;

    public class GetMaxBuyerQueryHandler : BaseService, IRequestHandler<GetMaxBuyerQuery, BuyerPersonResponseDto>
    {
        public GetMaxBuyerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<BuyerPersonResponseDto> Handle(GetMaxBuyerQuery request, CancellationToken cancellationToken)
        {
            var buyTransactions = await _unitOfWork.BuyTransactionReadRepository.GetAllAsynce();

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
