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
        public void Challenge_SuccessfullyAddToDatabase()
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
                Tags = new List<Tag> { new(new string('a', 5)) },
                Description = new string('a', 99999),
                ChallengeVisibility = Visibility.VisibleToAll,
                Deadline = DateTime.Now
            };

            challengeService.CreateChallenge(challenge);
            Assert.NotNull(challengeService.GetChallenge(id));
        }

        [Fact]
        public void Tag_TooLong_DontAddToDatabase()
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
                Description = "Description",
                Tags = new List<Tag> { new(new string('a', 51)) },
                ChallengeVisibility = Visibility.VisibleToAll,
                Deadline = DateTime.Now
            };

            challengeService.CreateChallenge(challenge);
            Assert.Null(challengeService.GetChallenge(id));
        }
    }
}
