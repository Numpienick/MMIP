using MMIP.Shared.Entities;

namespace MMIP.Application.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    IDataRepository<TEntity> Repository<TEntity>()
        where TEntity : BaseEntity;

    Task Commit(CancellationToken cancellationToken = default);

    Task Rollback();
}
