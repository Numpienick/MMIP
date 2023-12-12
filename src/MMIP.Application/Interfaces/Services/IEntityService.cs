using MMIP.Shared.Entities;

namespace MMIP.Application.Interfaces.Services;

public interface IEntityService<TEntity>
    where TEntity : BaseEntity
{
    public Task<TEntity?> GetByIdAsync(Guid id);
    public Task<TEntity?> GetReadonlyByIdAsync(Guid id);
    public Task<List<TEntity>> GetAllAsync();
    public Task<List<TEntity>> GetAllReadonlyAsync();
    public Task AddAsync(TEntity entity);
    public Task UpdateAsync(TEntity entity);
    public Task DeleteAsync(TEntity entity);
    public Task DeleteAsync(Guid id);
}
