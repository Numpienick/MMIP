using MMIP.Infrastructure.Repositories;
using MMIP.Infrastructure.Services;
using MMIP.Shared.Entities;
using MMIP.Shared.Enums;

namespace MMIP.Test.Unit
{
    public class ChallengeTest
    {
        [Fact]
        public void TooBigDescription_DoesntAddToDatabase()
        {
            var challengeRepository = new ChallengeRepository();

            ChallengeService challengeService = new ChallengeService(challengeRepository);
            Challenge challenge;
            Guid id = Guid.NewGuid();
            challenge = new Challenge
            {
                Id = id,
                Title = "Test",
                FinalReport = "Final Report",
                ShortDescription = "Short Description",
                Description = new string('a', 100001),
                ChallengeVisibility = Visibility.VisibleToAll,
                Deadline = DateTime.Now
            };

            challengeService.CreateChallenge(challenge);
            Assert.Null(challengeService.GetChallenge(id));
        }

        [Fact]
        public void Description_AddToDatabase()
        {
            var challengeRepository = new ChallengeRepository();

            ChallengeService challengeService = new ChallengeService(challengeRepository);
            Challenge challenge;
            Guid id = Guid.NewGuid();
            challenge = new Challenge
            {
                Id = id,
                Title = "Test",
                FinalReport = "Final Report",
                ShortDescription = "Short Description",
                Description = new string('a', 99999),
                ChallengeVisibility = Visibility.VisibleToAll,
                Deadline = DateTime.Now
            };

            challengeService.CreateChallenge(challenge);
            Assert.NotNull(challengeService.GetChallenge(id));
        }
    }
}
