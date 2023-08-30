using BornaTadbirTest.Domain.Entities.BuyTransactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BornaTadbirTest.Infrastructure.Entities.BuyTransactions
{
    public class BuyTransactionConfiguration : IEntityTypeConfiguration<BuyTransaction>
    {
        public void Configure(EntityTypeBuilder<BuyTransaction> builder)
        {
            builder.Property(t => t.Id).HasColumnName("TransactionId").ValueGeneratedOnAdd();
            builder.Property(t => t.PersonId).IsRequired();
            builder.Property(t => t.Price).IsRequired();
            builder.Property(t => t.CreatedDate).HasColumnName("TransactionDate").IsRequired();
        }
    }
}
