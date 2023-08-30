using BornaTadbirTest.Domain.Shared;

namespace BornaTadbirTest.Domain.Entities.Persons
{
    public class Person : BaseEntity
    {
        public string Name { get; private set; }
        public string Family { get; private set; }
        private Person()
        {

        }
        public static Person Create( string name, string family)
        {
            return new Person()
            {
                Name = name,
                Family = family,
                CreatedDate = DateTime.Now
            };
        }
    }
}
