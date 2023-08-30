using BornaTadbirTest.Domain.Shared;

namespace BornaTadbirTest.Domain.Shared.Interfaces
{
    public interface IWriteRepository<T> where T : BaseEntity
    {

        Task<T> AddAsync(T entity);

        Task<bool> DeleteByIdAsync(Guid id);

        Task<bool> DeleteAsync(T entity);

        Task<T> UpdateAsync(T entity);
    }
}

