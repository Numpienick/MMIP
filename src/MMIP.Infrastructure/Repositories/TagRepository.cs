using Microsoft.EntityFrameworkCore;
using MMIP.Application.Interfaces.Repositories;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly IDataRepository<Tag> _repository;

        public TagRepository(IDataRepository<Tag> repository)
        {
            _repository = repository;
        }

        public async Task<List<Tag>> Search(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return await _repository.GetAllAsync();
            value = value.ToLower();
            return await _repository.Entities
                .Where(t => t.Value.ToLower().Equals(value))
                .ToListAsync();
        }
    }
}
