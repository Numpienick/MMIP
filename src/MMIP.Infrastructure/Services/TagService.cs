using MMIP.Infrastructure.Repositories;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Services
{
    public class TagService : BaseEntityService<Tag>
    {
        private readonly TagRepository _tagRepository;

        public TagService(TagRepository repository)
            : base(repository)
        {
            _tagRepository = repository;
        }

        public List<Tag> GetTags(string value)
        {
            return _tagRepository.Search(value).Result;
        }
    }
}
