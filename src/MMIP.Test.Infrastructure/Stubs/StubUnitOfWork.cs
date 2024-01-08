using MMIP.Application.Interfaces.Repositories;
using MMIP.Shared.Entities;

namespace MMIP.Test.Infrastructure.Stubs;

public class StubUnitOfWork : IUnitOfWork
{
    private readonly StubApplicationContext _context;
    private readonly Dictionary<Type, object> _repositories = new();
    private bool _disposed;

    public StubUnitOfWork(StubApplicationContext context)
    {
        _context = context;
    }

    public IDataRepository<TEntity> Repository<TEntity>()
        where TEntity : BaseEntity
    {
        if (_repositories.ContainsKey(typeof(TEntity)))
        {
            return (IDataRepository<TEntity>)_repositories[typeof(TEntity)]!;
        }

        var repository = new StubDataRepository<TEntity>(_context);
        _repositories.Add(typeof(TEntity), repository);
        return repository;
    }

    public Task Commit(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    public Task Rollback()
    {
        _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        _disposed = true;
    }
}
