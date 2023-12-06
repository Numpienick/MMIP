using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Repositories
{
    internal class OrganizationRepository : BaseEntityRepository<Organization>
    {
        public override void Create(Organization organization)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Organization organization)
        {
            throw new NotImplementedException();
        }

        public override Task<IQueryable<Organization>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<IQueryable<Organization>> GetAllReadonly()
        {
            throw new NotImplementedException();
        }

        public override Task<Organization> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<Organization> GetReadonlyById(Guid id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Organization organization)
        {
            throw new NotImplementedException();
        }
    }
}
