using BornaTadbirTest.Domain.Shared;

namespace BornaTadbirTest.Domain.Entities.BuyTransactions
{
    public class BuyTransaction : BaseEntity
    {
        public int PersonId { get; private set; }
        public double Price { get; private set; }
        private BuyTransaction()
        {

        }
        public static BuyTransaction Create(int personId,DateTime transactionDate, double price)
        {
            return new BuyTransaction()
            {
                PersonId = personId,
                Price = price,
                CreatedDate = transactionDate
            };
        }
    }
}
