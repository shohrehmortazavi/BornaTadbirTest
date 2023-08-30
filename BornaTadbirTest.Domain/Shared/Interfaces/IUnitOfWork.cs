using BornaTadbirTest.Domain.Entities.BuyTransactions;
using BornaTadbirTest.Domain.Entities.Persons;

namespace BornaTadbirTest.Domain.Shared.Interfaces
{
    public interface IUnitOfWork : IBaseUnitOfWork
    {
        public IPersonReadRepository PersonReadRepository { get; }
        public IPersonWriteRepository PersonWriteRepository { get; }

        public IBuyTransactionReadRepository BuyTransactionReadRepository { get; }
        public IBuyTransactionWriteRepository BuyTransactionWriteRepository { get; }
    }
}
