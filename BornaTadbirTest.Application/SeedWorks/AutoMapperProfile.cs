using AutoMapper;
using BornaTadbirTest.Application.Entities.BuyTransactions.Dtos;
using BornaTadbirTest.Application.Entities.Persons.Dtos;
using BornaTadbirTest.Domain.Entities.BuyTransactions;
using BornaTadbirTest.Domain.Entities.Persons;

namespace BornaTadbirTest.Application.SeedWorks
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Person, PersonResponseDto>();
            CreateMap<BuyTransaction, BuyTransactionResponseDto>()
                .ForMember(x => x.TransactionDate, opt => opt.MapFrom(y => y.CreatedDate));

        }
    }
}
