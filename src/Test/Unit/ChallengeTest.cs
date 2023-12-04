using System.Text;
using Shared.Entities;
using Shared.Enums;
using Client.Controllers;
using Infrastructure.Services;
using Moq;
using MudBlazor;

namespace Test.Unit
{
    public class ChallengeTest
    {
        [Fact]
        public void TooBigDescription_DoesntAddToDatabase()
        {
            ChallengeService challengeService = new ChallengeService();
            var before = challengeService.GetChallenges(null);

            Challenge challenge;
            challenge = new Challenge
            {
                Title = "Test",
                FinalReport = "Final Report",
                ShortDescription = "Short Description",
                Description = new string('a', 100001),
                ChallengeVisibility = Visibility.VisibleToAll,
                Deadline = DateTime.Now
            };

            challengeService.CreateChallenge(challenge);
            var after = challengeService.GetChallenges(null);
            Assert.Equal(before.Count(), after.Count());
        }

        [Fact]
        public void Description_AddToDatabase()
        {
            ChallengeService challengeService = new ChallengeService();
            var before = challengeService.GetChallenges(null);

            Challenge challenge;
            challenge = new Challenge
            {
                Title = "Test",
                FinalReport = "Final Report",
                ShortDescription = "Short Description",
                Description = new string('a', 99999),
                ChallengeVisibility = Visibility.VisibleToAll,
                Deadline = DateTime.Now
            };

            challengeService.CreateChallenge(challenge);
            var after = challengeService.GetChallenges(null);
            Assert.Equal(before.Count() + 1, after.Count());
        }
    }
}
