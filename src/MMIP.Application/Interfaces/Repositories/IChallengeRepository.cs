using MMIP.Shared.Views;

namespace MMIP.Application.Interfaces.Repositories;

public interface IChallengeRepository
{
    Task<List<ChallengeCardView>> GetChallengeCardsAsync(int pageNumber, int pageSize);
}
