using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal abstract class BaseEntityRepository : IRepository
    {
        public abstract BaseEntity GetById(Guid id);

        public abstract BaseEntity GetReadonlyById(Guid id);

        public abstract IEnumerable<BaseEntity> GetAll();

        public abstract IEnumerable<BaseEntity> GetAllReadonly();

        public abstract void Create(BaseEntity entity);

        public abstract void Update(BaseEntity entity);

        public abstract void Delete(BaseEntity entity);
    }
}
