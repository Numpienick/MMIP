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
        public void IsDescriptionSizeValid()
        {
            string longString = new string('a', unchecked(0x0FFFFFF));

            var challenge = new Challenge
            {
                Title = "Test",
                FinalReport = "Final Report",
                ShortDescription = "Short Description",
                Description = longString,
                ChallengeVisibility = Visibility.VisibleToAll,
                Deadline = DateTime.Now
            };
            ChallengeService challengeService = new ChallengeService();
            challengeService.CreateChallenge(challenge);
        }
    }
}
