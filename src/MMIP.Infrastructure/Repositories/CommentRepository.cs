using MMIP.Application.Interfaces.Repositories;
using MMIP.Shared.Entities;
using MMIP.Shared.Views;

namespace MMIP.Infrastructure.Repositories
{
    internal class CommentRepository : ICommentRepository
    {
        private readonly IDataRepository<Comment> _repository;

        public CommentRepository(IDataRepository<Comment> repository)
        {
            _repository = repository;
        }

        public Task<List<CommentView>> GetCommentsViewAsync(
            Guid challengeId,
            int pageNumber,
            int pageSize
        )
        {
            return _repository.GetPagedResponseAsync<CommentView>(pageNumber, pageSize);
        }
    }
}
