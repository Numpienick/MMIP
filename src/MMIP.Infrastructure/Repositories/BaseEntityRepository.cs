﻿using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Repositories
{
    public abstract class BaseEntityRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        public abstract Task<TEntity?> GetById(Guid id);

        public abstract Task<TEntity> GetReadonlyById(Guid id);

        public abstract Task<IQueryable<TEntity>> GetAll();

        public abstract Task<IQueryable<TEntity>> GetAllReadonly();

        public abstract void Create(TEntity entity);

        public abstract void Update(TEntity entity);

        public abstract void Delete(TEntity entity);
    }
}
