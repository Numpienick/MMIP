using MMIP.Shared.Views;
using MMIP.Shared.Entities;

namespace MMIP.Application.Interfaces.Repositories;

public interface IChallengeRepository
{
    Task<List<ChallengeCardView>> GetChallengeCardsAsync(int pageNumber, int pageSize);
}
