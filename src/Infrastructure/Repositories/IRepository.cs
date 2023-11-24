using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal interface IRepository
    {
        public BaseEntity GetById(Guid id);
        public BaseEntity GetReadonlyById(Guid id);
        public IEnumerable<BaseEntity> GetAll();
        public IEnumerable<BaseEntity> GetAllReadonly();
        public void Create(BaseEntity entity);
        public void Update(BaseEntity entity);
        public void Delete(BaseEntity entity);
    }
}
