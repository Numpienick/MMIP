, using System.Text;
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
        public void IsDescriptionSizeInvalid()
        {
            Challenge challenge;
            try
            {
                challenge = new Challenge
                {
                    Title = "Test",
                    FinalReport = "Final Report",
                    ShortDescription = "Short Description",
                    Description = new string('a', 100001),
                    ChallengeVisibility = Visibility.VisibleToAll,
                    Deadline = DateTime.Now
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            ChallengeService challengeService = new ChallengeService();
            Assert.False(challengeService.CreateChallenge(challenge));
        }
        [Fact]
        public void IsDescriptionSizeValid()
        {
            Challenge challenge;
            try
            {
                challenge = new Challenge
                {
                    Title = "Test",
                    FinalReport = "Final Report",
                    ShortDescription = "Short Description",
                    Description = new string('a', 99999),
                    ChallengeVisibility = Visibility.VisibleToAll,
                    Deadline = DateTime.Now
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            ChallengeService challengeService = new ChallengeService();
            Assert.True(challengeService.CreateChallenge(challenge));
        }
    }
}
