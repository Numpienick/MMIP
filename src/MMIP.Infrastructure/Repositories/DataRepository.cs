using Microsoft.EntityFrameworkCore;
using MMIP.Application.Interfaces.Repositories;
using MMIP.Infrastructure.Context;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Repositories;

internal class DataRepository<TEntity> : IDataRepository<TEntity>
    where TEntity : class // TODO: revert back to BaseEntity and make a view repository
{
    private readonly ApplicationContext _context;

    public DataRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IQueryable<TEntity> Entities => _context.Set<TEntity>();

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public Task<List<TEntity>> GetAllAsync()
    {
        return _context.Set<TEntity>().ToListAsync();
    }

    public Task<List<T>> GetPagedResponseAsync<T>(int pageNumber, int pageSize)
        where T : class
    {
        return _context
            .Set<T>()
            .Skip((pageNumber) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public Task UpdateAsync(TEntity entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _context.Set<TEntity>().Attach(entity);
        }

        _context.Remove(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity != null)
            _context.Set<TEntity>().Remove(entity);
    }
}
