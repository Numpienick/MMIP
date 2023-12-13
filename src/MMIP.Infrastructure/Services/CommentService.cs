using MMIP.Application.Interfaces.Repositories;
using MMIP.Shared.Entities;
using MMIP.Shared.Views;

namespace MMIP.Infrastructure.Services
{
    public class CommentService : BaseEntityService<Comment>
    {
        private readonly IDataRepository<Comment> _repository;

        public CommentService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = unitOfWork.Repository<Comment>();
        }

        public Task<List<CommentView>> GetCommentViewAsync(int take, int skip)
        {
            int pageNumber = skip / take;
            return _repository.GetPagedResponseAsync<CommentView>(pageNumber, take);
        }
    }
}
