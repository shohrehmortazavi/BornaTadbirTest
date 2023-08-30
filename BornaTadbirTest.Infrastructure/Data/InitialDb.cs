using BornaTadbirTest.Domain.Entities.BuyTransactions;
using BornaTadbirTest.Domain.Entities.Persons;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BornaTadbirTest.Infrastructure.Data
{
    public static class InitialDb
    {
        public static void EnsureMigrationOfContext<T>(this IApplicationBuilder app) where T : AppDbContext
        {

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var _context = serviceScope.ServiceProvider.GetService<T>();
                _context.Database.Migrate();

                Seed(_context);
            }

        }

        private static void Seed<T>(T _context) where T : AppDbContext
        {
            try
            {
                if (!_context.Persons.Any())
                {
                    _context.Persons.Add(Person.Create("Jane", "Parker"));
                    _context.Persons.Add(Person.Create("Mike", "Copper"));
                    _context.SaveChanges();

                    var personId1 = _context.Persons.First().Id;
                    var personId2 = _context.Persons.Skip(1).First().Id;

                    _context.BuyTransactions.Add(BuyTransaction.Create(personId1, DateTime.Parse("2019/11/01 12:30"), 100000));
                    _context.BuyTransactions.Add(BuyTransaction.Create(personId1,  DateTime.Parse("2019/11/01 16:30"), 200000));
                    _context.BuyTransactions.Add(BuyTransaction.Create(personId1,  DateTime.Parse("2019/11/01 18:30"), 50000));
                    _context.BuyTransactions.Add(BuyTransaction.Create(personId1,  DateTime.Parse("2019/11/03 09:30"), 300000));
                    _context.BuyTransactions.Add(BuyTransaction.Create(personId2,  DateTime.Parse("2019/11/01 14:30"), 100000));
                    _context.BuyTransactions.Add(BuyTransaction.Create(personId2, DateTime.Parse("2019/11/01 12:30"), 20000));
                    _context.SaveChanges();

                }


                //    CreatePersons(_context);
                //    CreateBuyTransactions(_context);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private static void CreatePersons(AppDbContext _context)
        {
            _context.Database.EnsureCreated();
            if (!_context.Persons.Any())
            {
                _context.Persons.Add(Person.Create("Jane", "Parker"));
                _context.Persons.Add(Person.Create("Mike", "Copper"));
                _context.SaveChanges();
            }
        }

        private static void CreateBuyTransactions(AppDbContext _context)
        {
            _context.Database.EnsureCreated();
            if (!_context.BuyTransactions.Any())
            {
                _context.BuyTransactions.Add(BuyTransaction.Create(1, Convert.ToDateTime("2019/11/01 12:30"), 100000));
                _context.BuyTransactions.Add(BuyTransaction.Create(1, Convert.ToDateTime("2019/11/01 16:30"), 200000));
                _context.BuyTransactions.Add(BuyTransaction.Create(1, Convert.ToDateTime("2019/11/01 18:30"), 50000));
                _context.BuyTransactions.Add(BuyTransaction.Create(1, Convert.ToDateTime("2019/11/03 09:30"), 300000));
                _context.BuyTransactions.Add(BuyTransaction.Create(2, Convert.ToDateTime("2019/11/01 14:30"), 100000));
                _context.BuyTransactions.Add(BuyTransaction.Create(2, Convert.ToDateTime("2019/11/01 12:30"), 20000));
                _context.SaveChanges();
            }
        }

    }
}