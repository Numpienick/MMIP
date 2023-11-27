using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class ReactionRepository : BaseEntityRepository<Reaction>
    {
        public override void Create(Reaction reaction)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Reaction reaction)
        {
            throw new NotImplementedException();
        }

        public override Task<IQueryable<Reaction>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<IQueryable<Reaction>> GetAllReadonly()
        {
            throw new NotImplementedException();
        }

        public override Task<Reaction> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<Reaction> GetReadonlyById(Guid id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Reaction reaction)
        {
            throw new NotImplementedException();
        }
    }
}
