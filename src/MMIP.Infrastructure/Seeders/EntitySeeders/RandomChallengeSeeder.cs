using Microsoft.EntityFrameworkCore;
using MMIP.Application.Interfaces;
using MMIP.Infrastructure.Context;
using MMIP.Shared.Entities;
using MMIP.Shared.Enums;
using System;

namespace MMIP.Infrastructure.Seeders.EntitySeeders;

public class RandomChallengeSeeder : IEntitySeeder<Challenge>
{
    private readonly ApplicationContext _context;
    private readonly IEntitySeeder<Organization> _organizationSeeder;

    public RandomChallengeSeeder(
        ApplicationContext context,
        IEntitySeeder<Organization> organizationSeeder
    )
    {
        _context = context;
        _organizationSeeder = organizationSeeder;
    }

    public async Task Seed(int amount = 1)
    {
        var challenges = new List<Challenge>();
        var random = new Random();
        var visibilityValues = Enum.GetValues<Visibility>();
        var allOrganizations = (await _getOrganizations(random.Next(0, 12))).ToList();
        var allTags = (await _getTags(random.Next(0, 20))).ToArray();
        var allPhases = (await _getPhases(4)).ToArray();

        var testTitles = new List<string>
        {
            "Hoe kunnen we de klanttevredenheid verhogen?",
            "Hoe kunnen we onze ecologische voetafdruk verkleinen?",
            "Hoe kunnen we onze medewerkers meer betrekken en motiveren?",
            "Hoe kunnen we een sterke digitale conferentieplatform bouwen?",
            "Hoe kunnen we de internetsnelheid en verbindingen op afstand verbeteren?",
            "Hoe kunnen we phishing en gegevensprivacy problemen voorkomen?",
            "Hoe kunnen we een uitdagende en leuke coderingsuitdaging website maken?",
            "Hoe kunnen we een gepersonaliseerde en adaptieve leerplatform cre�ren?",
            "Hoe kunnen we een innovatieve en creatieve muziekapp maken?",
            "Hoe kunnen we een slimme en handige reisapp maken?"
        };
        var testDescriptions = new List<string>
        {
            "We willen weten wat onze klanten echt willen en nodig hebben, en hoe we hun verwachtingen kunnen overtreffen. We zoeken naar idee�n om onze klantenservice, ons productaanbod, onze prijsstrategie en onze communicatie te verbeteren.",
            "We willen onze impact op het milieu verminderen en bijdragen aan een duurzamere wereld. We zoeken naar idee�n om ons energieverbruik, onze afvalproductie, onze CO2-uitstoot en onze grondstoffen te verminderen of te compenseren.",
            "We willen dat onze medewerkers zich gewaardeerd, gerespecteerd en gehoord voelen. We zoeken naar idee�n om onze bedrijfscultuur, ons leiderschap, ons feedbacksysteem, onze beloningsstructuur en onze leer- en ontwikkelingsmogelijkheden te verbeteren.",
            "We willen een web- of mobiele app ontwikkelen die mensen in staat stelt om online vergaderingen, webinars, workshops en evenementen te organiseren en bij te wonen. We zoeken naar idee�n om onze app gebruiksvriendelijk, interactief, veilig en schaalbaar te maken.",
            "We willen een web- of mobiele app ontwikkelen die mensen helpt om hun internetsnelheid en verbindingen te optimaliseren, vooral als ze op afstand werken of leren. We zoeken naar idee�n om onze app slim, betrouwbaar, eenvoudig en nuttig te maken.",
            "We willen een web- of mobiele app ontwikkelen die mensen beschermt tegen phishing en gegevensprivacy problemen. We zoeken naar idee�n om onze app veilig, betrouwbaar, gebruiksvriendelijk en effectief te maken.",
            "We willen een website maken waar programmeurs coderingsuitdagingen kunnen oplossen in verschillende programmeertalen en niveaus. We zoeken naar idee�n om onze website aantrekkelijk, leerzaam, competitief en leuk te maken.",
            "We willen een web- of mobiele app ontwikkelen die mensen helpt om nieuwe vaardigheden te leren of bestaande vaardigheden te verbeteren. We zoeken naar idee�n om onze app gepersonaliseerd, adaptief, motiverend en effectief te maken.",
            "We willen een web- of mobiele app ontwikkelen die mensen in staat stelt om muziek te maken, te delen en te ontdekken. We zoeken naar idee�n om onze app innovatief, creatief, sociaal en leuk te maken.",
            "We willen een web- of mobiele app ontwikkelen die mensen helpt om hun reizen te plannen, te boeken en te beleven. We zoeken naar idee�n om onze app slim, handig, betrouwbaar en aantrekkelijk te maken."
        };
        var testShortDescriptions = new List<string>
        {
            "Verbeter de klanttevredenheid door beter te begrijpen wat de klant wil en nodig heeft.",
            "Verminder de ecologische voetafdruk door effici�nter en groener te werken.",
            "Verhoog de betrokkenheid en motivatie van de medewerkers door een positieve en ondersteunende werkomgeving te cre�ren.",
            "Bouw een digitale conferentieplatform die online samenwerking en communicatie mogelijk maakt.",
            "Verbeter de internetsnelheid en verbindingen op afstand met een slimme app.",
            "Voorkom phishing en gegevensprivacy problemen met een veilige app.",
            "Maak een coderingsuitdaging website die programmeurs uitdaagt en vermaakt.",
            "Cre�er een leerplatform die mensen helpt om hun leerdoelen te bereiken.",
            "Maak een muziekapp die mensen helpt om muziek te maken, te delen en te ontdekken.",
            "Maak een reisapp die mensen helpt om de wereld te verkennen."
        };

        for (int i = 0; i < amount; i++)
        {
            var phases = allPhases.Take(random.Next(1, allPhases.Length)).ToList();
            var visibility = (Visibility)(
                visibilityValues.GetValue(random.Next(visibilityValues.Length))
                ?? Visibility.VisibleToAll
            );
            var organizationId = allOrganizations[random.Next(0, allOrganizations.Count)].Id;
            var currentPhaseId = phases[random.Next(phases.Count)].Id;
            var tags = allTags.Take(random.Next(allTags.Length)).ToList();

            var curRandom = random.Next(0, testTitles.Count);
            challenges.Add(
                new Challenge
                {
                    Title = testTitles[curRandom],
                    Description = testDescriptions[curRandom],
                    ShortDescription = testShortDescriptions[curRandom],
                    Deadline = DateTime.Now.AddDays(10),
                    ChallengeVisibility = visibility,
                    BannerImagePath = $"https://picsum.photos/seed/{i}/556/200",
                    FinalReport = $"Final report {i}",
                    StartDate = DateTime.Now,
                    OrganizationId = organizationId,
                    CurrentPhaseId = currentPhaseId,
                    Tags = tags,
                    Phases = phases,
                }
            );
        }

        await _context.Challenges.AddRangeAsync(challenges);
        await _context.SaveChangesAsync();
    }

    private async Task<IEnumerable<Organization>> _getOrganizations(int amount)
    {
        var orgs = await _context.Organizations.Take(amount).ToListAsync();
        if (orgs.Count >= amount)
            return orgs;

        await _organizationSeeder.Seed(amount - orgs.Count);
        orgs.AddRange(_context.Organizations.Take(amount));

        return orgs;
    }

    private async Task<IEnumerable<Tag>> _getTags(int amount)
    {
        var tags = await _context.Tags.Take(amount).ToListAsync();
        var testTags = new List<Tag>
        {
            new() { Value = "Duurzaamheid" },
            new() { Value = "Energie" },
            new() { Value = "Gezondheid" },
            new() { Value = "ICT" },
            new() { Value = "Innovatie" },
            new() { Value = "Klimaat" },
            new() { Value = "Kunst" },
            new() { Value = "Leiderschap" },
            new() { Value = "Leren" },
            new() { Value = "Marketing" },
            new() { Value = "Media" },
            new() { Value = "Muziek" },
            new() { Value = "Onderwijs" },
            new() { Value = "Reizen" },
            new() { Value = "Sociaal" },
            new() { Value = "Sport" },
            new() { Value = "Technologie" },
            new() { Value = "Voeding" },
            new() { Value = "Wetenschap" },
            new() { Value = "Zorg" },
        };

        if (tags.Count >= amount)
            return tags;
        for (int i = 0; i < amount - tags.Count; i++)
        {
            tags.Add(new Tag { Value = testTags[i].Value });
        }

        return tags;
    }

    private async Task<IEnumerable<Phase>> _getPhases(int amount)
    {
        var phases = await _context.Phases.Take(amount).ToListAsync();
        if (phases.Count >= amount)
            return phases;
        for (int i = 0; i < amount - phases.Count; i++)
        {
            phases.Add(
                new Phase
                {
                    Id = Guid.NewGuid(),
                    Name = "Phase " + i,
                    Order = i + 1,
                    Description = "Description " + i,
                }
            );
        }

        return phases;
    }
}
