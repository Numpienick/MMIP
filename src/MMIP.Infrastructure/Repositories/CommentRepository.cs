using Microsoft.EntityFrameworkCore;
using MMIP.Application.Interfaces.Repositories;
using MMIP.Shared.Entities;
using MMIP.Shared.Views;

namespace MMIP.Infrastructure.Repositories
{
    internal class CommentRepository : ICommentRepository
    {
        private readonly IDataRepository<Comment> _repository;
        private readonly IDataRepository<CommentView> _viewRepository;

        public CommentRepository(
            IDataRepository<Comment> repository,
            IDataRepository<CommentView> viewRepository
        )
        {
            _repository = repository;
            _viewRepository = viewRepository;
        }

        public Task<List<CommentView>> GetCommentsViewAsync(
            Guid challengeId,
            int pageNumber,
            int pageSize
        )
        {
            return _repository.GetPagedResponseAsync<CommentView>(pageNumber, pageSize);
        }

        public async Task<List<CommentView?>> GetCommentViewAsync(Guid id)
        {
            return _viewRepository.Entities.Where(cv => cv.ChallengeId == id).ToList();
        }
    }
}
