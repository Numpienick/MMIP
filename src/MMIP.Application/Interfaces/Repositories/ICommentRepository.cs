using MMIP.Shared.Views;

namespace MMIP.Application.Interfaces.Repositories;

public interface ICommentRepository
{
    Task<List<CommentView>> GetCommentViewAsync(Guid id);
}
