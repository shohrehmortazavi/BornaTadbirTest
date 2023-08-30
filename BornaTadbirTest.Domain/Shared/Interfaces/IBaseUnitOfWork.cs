namespace BornaTadbirTest.Domain.Shared.Interfaces
{
    public interface IBaseUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();

    }
}
