using MMIP.Application.Interfaces.Repositories;
using MMIP.Infrastructure.Repositories;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Services
{
    public class TagService : BaseEntityService<Tag>
    {
        private readonly ITagRepository _repository;

        public TagService(IUnitOfWork unitOfWork, ITagRepository repository)
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public List<Tag> GetTags(string value)
        {
            return _repository.Search(value).Result;
        }
    }
}
