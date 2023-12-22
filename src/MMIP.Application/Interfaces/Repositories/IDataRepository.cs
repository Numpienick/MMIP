namespace MMIP.Application.Interfaces.Repositories;

public interface IDataRepository<TEntity>
    where TEntity : class // TODO: reset back to base entity and make a view repository
{
    public IQueryable<TEntity> Entities { get; }

    public Task<TEntity?> GetByIdAsync(Guid id);

    public Task<List<TEntity>> GetAllAsync();

    public Task<List<T>> GetPagedResponseAsync<T>(int pageNumber, int pageSize)
        where T : class;

    public Task AddAsync(TEntity entity);

    public Task UpdateAsync(TEntity entity);

    public Task DeleteAsync(TEntity entity);

    public Task DeleteAsync(Guid id);
}
