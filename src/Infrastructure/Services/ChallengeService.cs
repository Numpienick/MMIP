using Infrastructure.Repositories;
using Shared.Entities;
using Shared.Filters;
using Shared.StateContainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ChallengeService : BaseEntityService
    {
        private IEnumerable<Challenge> _challenges;

        // TODO: Remove when actual database works.
        public List<Challenge> FakeDatabaseInit()
        {
            List<Challenge> challenges = new List<Challenge>();
            Phase ongoing = new Phase();
            ongoing.Name = new Text(
                new DateTimeOffset(),
                new Guid(),
                null,
                new Guid(),
                new DateTimeOffset(),
                "Challenge gaande"
            );
            ongoing.Order = 3;

            Phase finished = new Phase();
            finished.Name = new Text(
                new DateTimeOffset(),
                new Guid(),
                null,
                new Guid(),
                new DateTimeOffset(),
                "Challenge afgerond"
            );
            finished.Order = 7;

            Challenge challenge1 = new Challenge();
            challenge1.Id = Guid.NewGuid();
            challenge1.Title = "[2] Recyclen plastic bekertjes";
            challenge1.ShortDescription =
                "Plastic is slecht voor het milieu. Voor deze challenge zoeken wij mensen die goede oplossingen hebben voor het plastic probleem.";
            challenge1.Tags = new string[] { "Recyclen", "Plastic", "Milieu" };
            challenge1.StartDate = new DateTimeOffset(new DateTime(2023, 9, 3));
            challenge1.Organization = new Organization();
            challenge1.Organization.Name = "Company Name";
            challenge1.BannerImagePath = "Assets/Img/1800x200.png";
            challenge1.Description =
                "Plastic wordt steeds vaker gevonden in de oceaan. Er zijn vrijwilligers die graag plastic en vuil van het strand willen opruimen. Echter zijn er lang niet genoeg vrijwilligers, en blijft er genoeg plastic zweven in de oceaan. Wij zoeken naar innovatieve oplossingen die dit probleem tegen kunnen gaan. Mensen die expertise in robotica of milieukunde hebben, zijn ideale kandidaten voor deze challenge. Daarnaast zijn wij op zoek naar mensen die minimaal een HBO-diploma hebben. Zou jij graag mee willen helpen aan dit probleem, of heb jij een genieus idee dat je achter wil laten? Laat dan vooral een reactie achter!";
            challenge1.Deadline = new DateTime(2023, 10, 3);
            challenge1.Phase = ongoing;
            challenges.Add(challenge1);

            Challenge challenge2 = new Challenge();
            challenge2.Id = Guid.NewGuid();
            challenge2.Title = "[3] Jongere docenten voor de klas";
            challenge2.ShortDescription =
                "Scholen hebben meer jongere docenten nodig. Heb jij een idee om jongere docenten te lokken om voor de klas te staan? Wij horen het graag!";
            challenge2.Tags = new string[] { "School", "Onderwijs", "Leraren", "Lesgeven" };
            challenge2.StartDate = new DateTimeOffset(new DateTime(2023, 10, 3));
            challenge2.Organization = new Organization();
            challenge2.Organization.Name = "Company Name";
            challenge2.BannerImagePath = "Assets/Img/1800x200.png";
            challenge2.Description =
                "Tegenwoordig is er een groot tekort aan docenten op het primair onderwijs. Het is van belang dat kinderen goed basisonderwijs krijgen. Hier heeft iedereen recht op. Het aantal studenten op de PABO wordt steeds lager, en steeds vaker stoppen studenten halverwege met de opleiding. Wij zijn op zoek naar iedeëen om meer studenten te lokken om de PABO te gaan studeren. Ben jij 18+, en heb jij een idee of suggestie? Dan horen wij dat graag!";
            challenge2.Deadline = new DateTime(2023, 10, 19);
            challenge2.FinalReport =
                "Een groepje studenten is met het idee gekomen om de kosten van de PABO opleidingen definitief te halveren. Daarnaast kwamen zij met het idee om werkloze jongeren in de klas te zetten als klassenhulp. Hierdoor verkrijgen zij werkervaring in de klas, en zouden zij na een aantal jaar zelfstandig voor een klas mogen staan.";
            challenge2.Phase = finished;
            challenges.Add(challenge2);

            Challenge challenge3 = new Challenge();
            challenge3.Id = Guid.NewGuid();
            challenge3.Title = "[1] Jongere docenten voor de klas";
            challenge3.ShortDescription =
                "Scholen hebben meer jongere docenten nodig. Heb jij een idee om jongere docenten te lokken om voor de klas te staan? Wij horen het graag!";
            challenge3.Tags = new string[] { "School", "Onderwijs", "Leraren", "Lesgeven" };
            challenge3.StartDate = new DateTimeOffset(new DateTime(2023, 7, 3));
            challenge3.Organization = new Organization();
            challenge3.Organization.Name = "Company Name";
            challenge3.BannerImagePath = "Assets/Img/556x200.jpg";
            challenges.Add(challenge3);

            Challenge challenge4 = new Challenge();
            challenge4.Id = Guid.NewGuid();
            challenge4.Title = "Jongere docenten voor de klas";
            challenge4.ShortDescription =
                "Scholen hebben meer jongere docenten nodig. Heb jij een idee om jongere docenten te lokken om voor de klas te staan? Wij horen het graag!";
            challenge4.Tags = new string[] { "School", "Onderwijs", "Leraren", "Lesgeven" };
            challenge4.StartDate = new DateTimeOffset(new DateTime(2023, 10, 21));
            challenge4.Organization = new Organization();
            challenge4.Organization.Name = "Company Name";
            challenge4.BannerImagePath = "Assets/Img/556x200.jpg";
            challenges.Add(challenge4);

            Challenge challenge5 = new Challenge();
            challenge5.Id = Guid.NewGuid();
            challenge5.Title = "Jongere docenten voor de klas";
            challenge5.ShortDescription =
                "Scholen hebben meer jongere docenten nodig. Heb jij een idee om jongere docenten te lokken om voor de klas te staan? Wij horen het graag!";
            challenge5.Tags = new string[] { "School", "Onderwijs", "Leraren", "Lesgeven" };
            challenge5.StartDate = new DateTimeOffset(new DateTime(2023, 10, 19));
            challenge5.Organization = new Organization();
            challenge5.Organization.Name = "Company Name";
            challenge5.BannerImagePath = "Assets/Img/556x200.jpg";
            challenges.Add(challenge5);

            Challenge challenge6 = new Challenge();
            challenge6.Id = Guid.NewGuid();
            challenge6.Title = "Jongere docenten voor de klas";
            challenge6.ShortDescription =
                "Scholen hebben meer jongere docenten nodig. Heb jij een idee om jongere docenten te lokken om voor de klas te staan? Wij horen het graag!";
            challenge6.Tags = new string[] { "School", "Onderwijs", "Leraren", "Lesgeven" };
            challenge6.StartDate = new DateTimeOffset(new DateTime(2023, 11, 19));
            challenge6.Organization = new Organization();
            challenge6.Organization.Name = "Company Name";
            challenge6.BannerImagePath = "Assets/Img/556x200.jpg";
            challenges.Add(challenge6);

            Challenge challenge7 = new Challenge();
            challenge7.Id = Guid.NewGuid();
            challenge7.Title = "Jongere docenten voor de klas";
            challenge7.ShortDescription =
                "Scholen hebben meer jongere docenten nodig. Heb jij een idee om jongere docenten te lokken om voor de klas te staan? Wij horen het graag!";
            challenge7.Tags = new string[] { "School", "Onderwijs", "Leraren", "Lesgeven" };
            challenge7.StartDate = new DateTimeOffset(new DateTime(2023, 11, 25));
            challenge7.Organization = new Organization();
            challenge7.Organization.Name = "Company Name";
            challenge7.BannerImagePath = "Assets/Img/556x200.jpg";
            challenges.Add(challenge7);

            _challenges = challenges;

            return challenges;
        }

        public void CreateChallenge() { }

        public Challenge GetChallenge(Guid id)
        {
            return TempStateContainer
                .Instance()
                .Challenges.FirstOrDefault(challenge => challenge.Id == id);
        }

        // TODO: Filter challenges based on filter criteria.
        public IEnumerable<Challenge> GetChallenges(ICriteria filterCriteria)
        {
            if (TempStateContainer.Instance().Challenges == null)
            {
                FakeDatabaseInit();
                TempStateContainer.Instance().Challenges = _challenges;
            }

            return TempStateContainer.Instance().Challenges;
        }

        public void UpdateChallenge(Challenge challenge) { }

        public void DeleteChallenge(Challenge challenge) { }
    }
}
