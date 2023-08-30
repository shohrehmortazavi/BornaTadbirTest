using BornaTadbirTest.Domain.Entities.BuyTransactions;
using BornaTadbirTest.Domain.Entities.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BornaTadbirTest.Infrastructure.Entities.Persons
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(t => t.Id).HasColumnName("PersonId").ValueGeneratedOnAdd();
            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Family).HasMaxLength(100).IsRequired();

            builder.HasMany<BuyTransaction>().WithOne();

        }
    }
}
