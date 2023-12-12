using Microsoft.EntityFrameworkCore;
using MMIP.Application.Interfaces.Repositories;
using MMIP.Application.Interfaces.Services;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Services
{
    public class BaseEntityService<TEntity> : IEntityService<TEntity>
        where TEntity : BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDataRepository<TEntity> _repository;

        internal BaseEntityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.Repository<TEntity>();
        }

        public Task<TEntity?> GetByIdAsync(Guid id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<TEntity?> GetReadonlyByIdAsync(Guid id)
        {
            return _repository.Entities.AsNoTracking().SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<List<TEntity>> GetAllReadonlyAsync()
        {
            return _repository.Entities.AsNoTracking().ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.Commit();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
            await _unitOfWork.Commit();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await _repository.DeleteAsync(entity);
            await _unitOfWork.Commit();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.Commit();
        }
    }
}
