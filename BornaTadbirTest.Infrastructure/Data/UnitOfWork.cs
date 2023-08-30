using BornaTadbirTest.Domain.Entities.BuyTransactions;
using BornaTadbirTest.Domain.Entities.Persons;
using BornaTadbirTest.Domain.Shared.Interfaces;
using BornaTadbirTest.Infrastructure.Entities.BuyTransactions;
using BornaTadbirTest.Infrastructure.Entities.Persons;

namespace BornaTadbirTest.Infrastructure.Data
{
    public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
    {
        public UnitOfWork(AppDbContext context) : base(context)
        {
        }

        public IPersonReadRepository PersonReadRepository => new PersonReadRepository(AppDbContext());
        public IPersonWriteRepository PersonWriteRepository => new PersonWriteRepository(AppDbContext());

        public IBuyTransactionReadRepository BuyTransactionReadRepository => new BuyTransactionReadRepository(AppDbContext());
        public IBuyTransactionWriteRepository BuyTransactionWriteRepository => new BuyTransactionWriteRepository(AppDbContext());
    }
}
