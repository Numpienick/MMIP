using MMIP.Shared.Entities;

namespace MMIP.Application.Interfaces;

public interface IEntitySeeder<TEntity>
    where TEntity : BaseEntity
{
    public Task Seed(int amount = 1);
}