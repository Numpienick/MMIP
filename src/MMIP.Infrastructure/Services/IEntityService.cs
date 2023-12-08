using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Services
{
    public interface IEntityService<TEntity>
        where TEntity : BaseEntity
    {
        Task<TEntity?> GetByIdAsync(Guid id);
    }
}
