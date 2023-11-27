using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class UserRepository : BaseEntityRepository<User>
    {
        public override void Create(User user)
        {
            throw new NotImplementedException();
        }

        public override void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public override Task<IQueryable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<IQueryable<User>> GetAllReadonly()
        {
            throw new NotImplementedException();
        }

        public override Task<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<User> GetReadonlyById(Guid id)
        {
            throw new NotImplementedException();
        }

        public override void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
