using BornaTadbirTest.Domain.Entities.BuyTransactions;
using BornaTadbirTest.Infrastructure.Data;

namespace BornaTadbirTest.Infrastructure.Entities.BuyTransactions
{
    public class BuyTransactionWriteRepository : WriteRepository<BuyTransaction>, IBuyTransactionWriteRepository
    {
        public BuyTransactionWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
