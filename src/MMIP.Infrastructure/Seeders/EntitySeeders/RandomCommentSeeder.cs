using Microsoft.EntityFrameworkCore;
using MMIP.Application.Interfaces;
using MMIP.Infrastructure.Context;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Seeders.EntitySeeders;

public class RandomCommentSeeder : IEntitySeeder<Comment>
{
    private readonly ApplicationContext _context;

    public RandomCommentSeeder(ApplicationContext context)
    {
        _context = context;
    }

    public async Task Seed(int amount = 40)
    {
        var comments = new List<Comment>();
        var random = new Random();
        var challengeIds = await _context.Challenges.Select(c => c.Id).ToArrayAsync();
        var commentTypeIds = await _context.CommentTypes.Select(c => c.Id).ToArrayAsync();
        for (int i = 0; i < amount; i++)
        {
            comments.Add(
                new Comment
                {
                    Text = $"Comment {i}",
                    ChallengeId = challengeIds[random.Next(challengeIds.Length)],
                    CommentTypeId = commentTypeIds[random.Next(commentTypeIds.Length)],
                    Concluded = random.Next(0, 2) == 1,
                    CreatedDate = DateTimeOffset.Now.AddDays(-random.Next(1, 100)),
                }
            );
        }

        await _context.AddRangeAsync(comments);
        await _context.SaveChangesAsync();
    }
}
