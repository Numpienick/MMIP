using MMIP.Shared.Views;

namespace MMIP.Application.Interfaces.Repositories;

public interface IChallengeRepository
{
    Task<List<ChallengeCardComponentView>> GetChallengeCardsAsync(int pageNumber, int pageSize);
}
