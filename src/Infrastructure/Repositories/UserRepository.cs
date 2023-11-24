using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class UserRepository : BaseEntityRepository
    {
        public override void Create(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<BaseEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<BaseEntity> GetAllReadonly()
        {
            throw new NotImplementedException();
        }

        public override BaseEntity GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public override BaseEntity GetReadonlyById(Guid id)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
