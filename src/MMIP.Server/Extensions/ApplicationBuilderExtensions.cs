using MMIP.Infrastructure.Context;
using MMIP.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;

namespace MMIP.Server.Extensions;

internal static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Initializes the database with the given seeders.
    /// </summary>
    /// <param name="app"></param>
    /// <param name="ensureDeleted">CAUTION: Will drop the database including all its data so a fresh database is generated.</param>
    internal static async Task<IApplicationBuilder> Initialize(
        this IApplicationBuilder app,
        bool ensureDeleted = false
    )
    {
        using var scope = app.ApplicationServices.CreateScope();

        var services = scope.ServiceProvider;
        var contextFactory = services.GetRequiredService<IDbContextFactory<ApplicationContext>>();
        var context = await contextFactory.CreateDbContextAsync();

        if (ensureDeleted)
            await context.Database.EnsureDeletedAsync();

        await context.Database.MigrateAsync();

        var seeders = services.GetServices<IDatabaseSeeder>();
        foreach (var seeder in seeders)
        {
            await seeder.Initialize();
        }

        // TODO: Remove this line later.
        var views = await context.CommentViews.ToListAsync();
        return app;
    }
}
