using BornaTadbirTest.Domain.Shared;
using BornaTadbirTest.Domain.Shared.Interfaces;

namespace BornaTadbirTest.Infrastructure.Data
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public WriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            var entryEntity = await _context.Set<T>().AddAsync(entity);
            return entryEntity.Entity;
        }

        public Task<bool> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteByIdAsync(Guid id)
        {
            T entity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity);
            return Task.FromResult(true);
        }

        public Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return Task.FromResult(entity);
        }

    }
}
