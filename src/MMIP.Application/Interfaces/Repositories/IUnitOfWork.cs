using MMIP.Shared.Entities;

namespace MMIP.Application.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    IDataRepository<TEntity> Repository<TEntity>()
        where TEntity : class; //TODO: revert back to BaseEntity and make a view repository

    Task Commit(CancellationToken cancellationToken = default);

    Task Rollback();
}
