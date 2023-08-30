using BornaTadbirTest.Domain.Entities.Persons;
using BornaTadbirTest.Infrastructure.Data;

namespace BornaTadbirTest.Infrastructure.Entities.Persons
{
    public class PersonWriteRepository : WriteRepository<Person>, IPersonWriteRepository
    {
        public PersonWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
