using MMIP.Shared.Entities;

namespace MMIP.Application.Interfaces.Repositories;

public interface ITagRepository
{
    public Task<List<Tag>> Search(string value);
}
