using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal abstract class BaseEntityRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        public abstract Task<TEntity> GetById(Guid id);

        public abstract Task<TEntity> GetReadonlyById(Guid id);

        public abstract Task<IQueryable<TEntity>> GetAll();

        public abstract Task<IQueryable<TEntity>> GetAllReadonly();

        public abstract void Create(TEntity entity);

        public abstract void Update(TEntity entity);

        public abstract void Delete(TEntity entity);
    }
}
