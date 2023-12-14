using MMIP.Application.Interfaces.Repositories;
using MMIP.Shared.Entities;
using MMIP.Shared.Views;

namespace MMIP.Infrastructure.Services
{
    public class CommentService : BaseEntityService<Comment>
    {
        private readonly ICommentRepository _repository;

        public CommentService(IUnitOfWork unitOfWork, ICommentRepository repository)
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public Task<List<CommentView?>> GetCommentViewAsync(Guid id)
        {
            return _repository.GetCommentViewAsync(id);
        }
    }
}
