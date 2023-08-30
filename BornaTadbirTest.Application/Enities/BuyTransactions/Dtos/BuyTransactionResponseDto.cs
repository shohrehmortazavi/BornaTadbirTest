namespace BornaTadbirTest.Application.Entities.BuyTransactions.Dtos
{
    public class BuyTransactionResponseDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public double Price { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
