using Microsoft.EntityFrameworkCore;
using MMIP.Infrastructure.Context;
using MMIP.Infrastructure.Helpers;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Seeders;

public class DefaultsSeeder : IDatabaseSeeder
{
    private readonly ApplicationContext _context;

    public DefaultsSeeder(ApplicationContext context)
    {
        _context = context;
    }

    public async Task Initialize()
    {
        await _seedSectors();
        await _seedDefaultOrganization();
        await _seedDefaultCommentTypes();
    }

    private async Task _seedDefaultCommentTypes()
    {
        var commentTypes = new List<CommentType>()
        {
            new()
            {
                Name = "Ik heb een vraag!",
                Description =
                    "Deze type reactie houdt in dat de gebruiker een vraag heeft over de challenge. De maker van de challenge kan hierbij de gebruiker een mailtje sturen om de vraag te beantwoorden.",
                IconPath = "Assets/Img/CommentQuestion.png"
            },
            new()
            {
                Name = "Ik heb feedback!",
                Description =
                    "Deze type reactie houdt in dat de gebruiker feedback heeft over de challenge. Feedback kan variëren van typefouten tot missende informatie.",
                IconPath = "Assets/Img/CommentFeedback.png"
            },
            new()
            {
                Name = "Ik zou de challenge willen uitvoeren!",
                Description =
                    "Deze type reactie houdt in dat de gebruiker zich openstelt om de challenge uit te voeren. De maker van de challenge kan de reactie afvinken en de gebruiker laten weten dat hij of zij is uitgekozen om de challenge uit te voeren.",
                IconPath = "Assets/Img/CommentParticipation.png"
            },
            new()
            {
                Name = "Ik heb een idee!",
                Description =
                    "Deze type reactie houdt in dat de gebruiker een idee heeft dat bij de challenge past. De maker van de challenge kan goede ideeën afvinken en toevoegen aan de challenge.",
                IconPath = "Assets/Img/CommentIdea.png"
            }
        };

        var duplicates = _context
            .Set<CommentType>()
            .Select(ct => ct.Name)
            .Where(ctName => commentTypes.Select(ct => ct.Name).Contains(ctName));

        await _context.AddRangeAsync(commentTypes.Where(ct => !duplicates.Contains(ct.Name)));
        await _context.SaveChangesAsync();
    }

    private async Task _seedDefaultOrganization()
    {
        var orgId = Guid.Parse("00000000-0000-0000-0000-000000000001");
        if (await _doesEntityExist<Organization>(orgId))
            return;

        var sector = await _context.Sectors.FirstOrDefaultAsync();
        if (sector == default)
        {
            await _seedSectors();
            sector = await _context.Sectors.FirstAsync();
        }

        var orgProfile = new OrganizationProfile
        {
            AvatarPath = $"https://picsum.photos/seed/{new Random().Next(999999)}/400/400",
            Description =
                "Default Organization Description Default Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization DescriptionDefault Organization Description",
            BannerImagePath = $"https://picsum.photos/seed/{new Random().Next(999999)}/1600/888"
        };

        var org = new Organization
        {
            Id = orgId,
            Name = "Default Organization",
            EnrollmentCode = EnrollmentCodeGenerator.GenerateEnrollmentCode(),
            Sector = sector,
            Profile = orgProfile,
        };
        await _context.Organizations.AddAsync(org);
        await _context.SaveChangesAsync();
    }

    private async Task _seedSectors()
    {
        var sectors = new List<Sector>()
        {
            new() { Id = Guid.NewGuid(), Name = "Gezondheidszorg en -welzijn" },
            new() { Id = Guid.NewGuid(), Name = "Handel en dienstverlening" },
            new() { Id = Guid.NewGuid(), Name = "ICT" },
            new() { Id = Guid.NewGuid(), Name = "Milieu en Agrarische sector" },
            new() { Id = Guid.NewGuid(), Name = "Media en communicatie" },
            new() { Id = Guid.NewGuid(), Name = "Onderwijs, cultuur en wetenschap" },
            new() { Id = Guid.NewGuid(), Name = "Techniek, productie en bouw" },
            new() { Id = Guid.NewGuid(), Name = "Toerisme, recreatie en horeca" },
            new() { Id = Guid.NewGuid(), Name = "Transport en logistiek" },
        };

        foreach (var sector in sectors)
        {
            if (await _doesEntityExist<Sector>(sector.Id))
                continue;
            await _context.Sectors.AddAsync(sector);
        }

        await _context.SaveChangesAsync();
    }

    private async Task<bool> _doesEntityExist<TEntity>(Guid id)
        where TEntity : BaseEntity => await _context.Set<TEntity>().FindAsync(id) != null;
}
