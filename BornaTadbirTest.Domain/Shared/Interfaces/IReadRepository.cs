using System.Linq.Expressions;

namespace BornaTadbirTest.Domain.Shared.Interfaces
{
    public interface IReadRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);

        Task<List<T>> GetAllAsynce();

        Task<List<T>> Find(Expression<Func<T, bool>> expression);
    }
}
