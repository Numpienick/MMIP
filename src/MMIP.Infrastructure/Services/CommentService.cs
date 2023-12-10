using MMIP.Application.Interfaces.Repositories;
using MMIP.Shared.Entities;

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

        public async Task<List<Comment>> GetCommentsByChallengeIdAsync(Guid challengeId)
        {
            throw new NotImplementedException();
        }
    }
}
