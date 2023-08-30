using BornaTadbirTest.Domain.Entities.Persons;
using BornaTadbirTest.Infrastructure.Data;

namespace BornaTadbirTest.Infrastructure.Entities.Persons
{
    public class PersonReadRepository : ReadRepository<Person>, IPersonReadRepository
    {
        public PersonReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
