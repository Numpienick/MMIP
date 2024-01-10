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
            AvatarPath = $"https://picsum.photos/seed/{new Random().Next(999999)}/1000/1000",
            Description =
                @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer ut fermentum tellus. Sed convallis dui a ultrices consectetur. Pellentesque facilisis, arcu ac aliquam pretium, enim massa pellentesque ipsum, et faucibus nisl nisl iaculis dolor. In faucibus commodo ultrices. Aenean convallis fringilla porta. Suspendisse dictum semper justo ut porta. Aliquam erat volutpat. In sed consequat metus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Vestibulum euismod nisl ac nulla accumsan, in ultrices mauris fermentum. Nam bibendum ligula est, sit amet iaculis mauris feugiat ut.

Mauris mi ligula, malesuada tempus velit non, varius luctus elit. Donec in consequat sapien. Sed pulvinar urna bibendum elementum rutrum. Sed tristique urna leo, ut sollicitudin ex consequat non. Suspendisse molestie, purus nec sagittis elementum, tortor metus porta velit, ut interdum libero nunc et nibh. Donec ut neque tristique dui condimentum lacinia. Mauris nec urna non urna lobortis sodales. Curabitur ac scelerisque mauris. Donec blandit maximus magna et aliquet. Integer quis elit ligula. Proin nec venenatis elit. Phasellus malesuada velit condimentum, placerat orci vel, dapibus neque. Nulla lacinia, elit vitae fringilla porttitor, velit est molestie mi, ac sollicitudin ipsum lacus nec justo.

Quisque semper justo sagittis urna laoreet facilisis ut aliquet massa. Etiam elementum odio ut urna mollis, nec pretium nibh rhoncus. Etiam ac fermentum magna. Quisque auctor eros id lorem consequat, a commodo nulla aliquet. Maecenas mollis tincidunt nisl vitae faucibus. Maecenas molestie a purus ut lobortis. Aliquam lectus ante, interdum eu magna id, viverra tempor ex. Suspendisse a ex a mi vehicula bibendum. Interdum et malesuada fames ac ante ipsum primis in faucibus.

Suspendisse id lacinia lectus. In eu eros sem. Integer mollis elementum diam nec tristique. Nulla at mauris tortor. Cras malesuada ipsum vel enim lobortis pharetra. Nulla dapibus elit a euismod hendrerit. Nunc erat eros, porta at suscipit vitae, maximus nec mi. Nunc varius vestibulum diam. Quisque tempus luctus dui, dapibus pretium ipsum blandit eget. Sed a ligula euismod, blandit libero non, aliquet elit. In iaculis libero id nunc tincidunt consequat. Praesent volutpat arcu nec porttitor consequat.

Nullam sed sem tristique, imperdiet dolor sed, lacinia est. Aenean a bibendum tellus. Quisque semper, dolor quis rutrum vulputate, libero massa aliquam quam, nec ornare tellus nisi facilisis arcu. Fusce bibendum odio id laoreet hendrerit. Cras eget dui ac turpis accumsan tristique. Nam malesuada eu nibh id convallis. Sed auctor metus eget leo pellentesque placerat. Pellentesque nec gravida libero. Nullam dictum hendrerit dolor, sed finibus lectus malesuada sed. Donec sodales purus et maximus rutrum. Aliquam et tincidunt nibh, aliquet consequat risus. Vivamus sed aliquet ex, nec sodales felis. Maecenas blandit at tellus quis accumsan. Proin at interdum nisi. Fusce pharetra metus massa, quis dignissim justo scelerisque sed. Fusce dictum aliquet magna, a pellentesque mi tempor quis.

Aliquam erat volutpat. Fusce malesuada, mi eu tincidunt euismod, diam est pulvinar dolor, vitae fringilla quam massa at mi. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nam ultrices odio sit amet enim tempus viverra. Integer congue viverra enim, vitae aliquet eros. Curabitur consectetur est eros, vitae iaculis risus consequat quis. Vivamus vel suscipit libero. Curabitur et dictum sapien, quis tempor neque. Donec ac consectetur nunc. Cras vel urna eget erat molestie varius. In augue nulla, maximus eu ligula a, sodales vulputate augue. Ut id mauris pretium, viverra turpis sed, ullamcorper nibh.

Mauris tristique eros eu elit semper dignissim. Phasellus sed ultrices velit. Nulla facilisi. Suspendisse consectetur odio sodales lobortis tempus. Nullam a odio bibendum, dignissim enim et, rutrum justo. Nullam fermentum condimentum nisl, at porttitor ipsum semper ut. Integer eu eleifend nibh. Proin congue placerat lacus vel aliquam. Integer sed lacinia dui, ut tincidunt elit.

Maecenas ullamcorper purus vitae lectus rhoncus, eget porttitor tortor facilisis. Vivamus accumsan, diam non molestie elementum, massa tellus interdum metus, id volutpat eros erat sit amet lorem. Sed a pretium massa, vitae tincidunt nunc. Nam lectus enim, porttitor quis eros vel, rutrum euismod massa. Quisque nec lectus id elit gravida interdum vel non ipsum. Vestibulum eget libero risus. Etiam placerat ac lectus non ullamcorper. In egestas pharetra est vel dapibus. Curabitur malesuada accumsan mattis. Fusce auctor, tellus nec molestie blandit, purus nisl sollicitudin lectus, in condimentum sapien diam eu augue. Vivamus ut molestie felis. Fusce sollicitudin euismod scelerisque. Nam eu nisi vel sem dictum pharetra. Pellentesque egestas ipsum libero, et molestie dolor lobortis vel.

Pellentesque ullamcorper, erat sit amet euismod commodo, mauris dolor tincidunt est, ac hendrerit dolor augue non nisi. Suspendisse lacinia euismod condimentum. Integer sit amet risus eu est tempus volutpat sit amet sit amet diam. Proin bibendum sagittis nibh, non venenatis mauris condimentum vitae. Curabitur eu orci vitae libero commodo sollicitudin vel eget nibh. Suspendisse sollicitudin lectus neque, sit amet finibus lacus vestibulum nec. Nulla luctus ex nibh. Mauris at dui quis tellus pharetra tristique. Etiam nulla odio, porttitor ac malesuada vel, pellentesque vitae arcu. Sed et ligula interdum, porttitor metus sit amet, ornare est. Vivamus mollis varius magna nec malesuada. Integer feugiat interdum eleifend. Quisque ultrices tincidunt arcu in maximus. Sed pretium ante in orci dictum, ac porttitor tellus mattis. Curabitur ipsum metus, posuere vel semper eu, facilisis sit amet diam. Fusce sagittis enim nec sapien ullamcorper, non feugiat ante suscipit.

Phasellus sodales ultricies mauris. Suspendisse potenti. Maecenas felis metus, porta at tortor vitae, tincidunt sollicitudin odio. Phasellus tellus risus, ullamcorper non volutpat sed, tempus at ante. Nullam pellentesque tempus facilisis. Sed a lorem egestas, pretium ante vitae, laoreet mi. In consequat gravida tellus, eu malesuada magna bibendum eu. Mauris ac tellus orci. Sed hendrerit volutpat mauris a tincidunt. Phasellus accumsan erat sed nisi egestas rhoncus. Aliquam a dolor quis velit lobortis pretium at sed leo. Aenean scelerisque at nibh quis condimentum.

In hac habitasse platea dictumst. Donec sem dolor, imperdiet eget massa vel, feugiat molestie tortor. Quisque vitae nisl quis purus facilisis scelerisque. Aliquam vel mattis odio. Maecenas molestie facilisis risus, ut imperdiet lorem. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nullam ac aliquam erat. Fusce dui sem, facilisis scelerisque faucibus eget, lobortis vitae nibh.

Donec varius dui id purus lobortis commodo. Donec cursus auctor sem, ac vulputate enim consectetur eget. Curabitur posuere nisl justo, quis sollicitudin elit tincidunt vel. Fusce ut lectus eget ex tempor imperdiet ac sit amet ipsum. In hac habitasse platea dictumst. Nunc fringilla finibus accumsan. Cras et mi a nunc volutpat aliquet a ac nisl. Donec interdum tortor a purus imperdiet tincidunt. Curabitur fermentum finibus aliquam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin eu mi euismod, aliquam dui nec, congue risus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Vestibulum tincidunt libero risus, placerat gravida libero congue sit amet.

Sed mollis auctor iaculis. Pellentesque at aliquet tortor. Morbi aliquam nulla ut elementum rhoncus. Integer volutpat aliquam luctus. Ut volutpat et lacus a lobortis. In tempus pellentesque turpis vel volutpat. Sed quis aliquam nibh, non tristique augue. Ut vehicula dictum auctor. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; In hac habitasse platea dictumst. Quisque quis leo diam. Proin vitae velit non dolor pharetra aliquet. Suspendisse potenti.

Suspendisse a lacinia ligula. Proin sit amet nisl turpis. Mauris tempus lacinia est, ut laoreet mi tincidunt in. Nulla faucibus erat quis mauris rhoncus lobortis. Praesent ullamcorper porttitor bibendum. Morbi ac mi pharetra, tincidunt odio sed, commodo tortor. Curabitur mattis dui ac metus sollicitudin, vel consectetur arcu pharetra. Ut consectetur velit sed nibh rutrum fermentum. Aliquam urna nulla, fermentum vel convallis in, dictum eget neque.

Donec mattis tellus sit amet tincidunt suscipit. Integer facilisis arcu quis erat convallis rhoncus. Aliquam et elementum odio. Curabitur in facilisis magna, non lacinia lorem. Aliquam bibendum tempor neque, sed condimentum eros convallis id. Proin cursus, sem id volutpat luctus, turpis eros vestibulum purus, eu pulvinar odio tortor hendrerit leo. Nullam id faucibus justo. Aliquam vestibulum eros libero. Pellentesque aliquet maximus facilisis. Duis vel.",
            BannerImagePath = $"https://picsum.photos/seed/{new Random().Next(999999)}/1600/888"
        };

        var org = new Organization
        {
            Id = orgId,
            Name =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus posuere, est quis egestas condimentum, nisi velit mattis dolor.",
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
