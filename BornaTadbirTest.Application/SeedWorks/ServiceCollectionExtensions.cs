using BornaTadbirTest.Domain.Shared.Interfaces;
using BornaTadbirTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BornaTadbirTest.Application.SeedWorks
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString, x =>
            {
                x.MigrationsAssembly(typeof(AppDbContext).Assembly.ToString());
                x.UseDateOnlyTimeOnly();
            }));
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>))
                .AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        //public static IServiceCollection AddServices(this IServiceCollection services)
        //{
        //    return services.AddScoped<ICalculateDailyTaxService, CalculateDailyTaxService>();
        //}
    }
}

