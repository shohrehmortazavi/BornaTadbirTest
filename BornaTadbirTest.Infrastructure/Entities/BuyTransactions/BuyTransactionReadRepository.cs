using BornaTadbirTest.Domain.Entities.BuyTransactions;
using BornaTadbirTest.Infrastructure.Data;

namespace BornaTadbirTest.Infrastructure.Entities.BuyTransactions
{
    public class BuyTransactionReadRepository : ReadRepository<BuyTransaction>, IBuyTransactionReadRepository
    {
        public BuyTransactionReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
