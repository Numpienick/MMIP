using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Repositories
{
    public class TagRepository : BaseEntityRepository<Tag>
    {
        private List<Tag> _tags = new();
        private IQueryable<Tag> _allTags;

        public TagRepository()
        {
            _allTags = GetAll().Result;
        }

        public async Task<List<Tag>> Search(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return _allTags.ToList();
            return _allTags.Where(tag => tag.Value.ToLower().Contains(value.ToLower())).ToList();
        }

        public override Task<Tag> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<Tag> GetReadonlyById(Guid id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IQueryable<Tag>> GetAll()
        {
            _tags.Add(new Tag("Recyclen"));
            _tags.Add(new Tag("Plastic"));
            _tags.Add(new Tag("Milieu"));
            IQueryable<Tag> allTags = _tags.AsQueryable();

            return allTags;
        }

        public override Task<IQueryable<Tag>> GetAllReadonly()
        {
            throw new NotImplementedException();
        }

        public override void Create(Tag entity)
        {
            throw new NotImplementedException();
            //TODO: reset _allTags after adding
        }

        public override void Update(Tag entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Tag entity)
        {
            throw new NotImplementedException();
        }
    }
}
