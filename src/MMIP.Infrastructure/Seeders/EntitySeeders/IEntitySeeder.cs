using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Seeders.EntitySeeders;

public interface IEntitySeeder<TEntity>
    where TEntity : BaseEntity
{
    public Task Seed(int amount = 1);
}
