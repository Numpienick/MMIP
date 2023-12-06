using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Repositories
{
    internal interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        public Task<TEntity> GetById(Guid id);
        public Task<TEntity> GetReadonlyById(Guid id);
        public Task<IQueryable<TEntity>> GetAll();
        public Task<IQueryable<TEntity>> GetAllReadonly();
        public void Create(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
    }
}
