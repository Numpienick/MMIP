using MMIP.Shared.Views;

namespace MMIP.Application.Interfaces.Repositories;

public interface ICommentRepository
{
    Task<List<CommentView>> GetCommentsViewAsync(Guid challengeId, int pageNumber, int pageSize);
}
