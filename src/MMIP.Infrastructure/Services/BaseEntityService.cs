using MMIP.Infrastructure.Repositories;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Services
{
    public class BaseEntityService<TEntity> : IEntityService<TEntity>
        where TEntity : BaseEntity
    {
        internal readonly IRepository<TEntity> Repository;

        internal BaseEntityService(IRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public Task<TEntity?> GetByIdAsync(Guid id)
        {
            return Repository.GetById(id);
        }
    }
}
