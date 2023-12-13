using MMIP.Environment;
using MMIP.Infrastructure.Context;
using MMIP.Infrastructure.Seeders;
using MMIP.Infrastructure.Seeders.EntitySeeders;
using Microsoft.EntityFrameworkCore;
using MMIP.Application.Interfaces;
using MMIP.Shared.Entities;

namespace MMIP.Server.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddDatabase(
        this IServiceCollection services,
        bool addRandomDataSeeder = false
    )
    {
#if DEBUG
        services
            .AddDbContextFactory<ApplicationContext>(
                opt =>
                    opt.UseNpgsql(EnvironmentConstants.DatabaseConnectionString())
                        .UseSnakeCaseNamingConvention()
                        .EnableSensitiveDataLogging()
            )
            .AddDatabaseDeveloperPageExceptionFilter();
#else
        services
            .AddDbContextFactory<ApplicationContext>(
                opt =>
                    opt.UseNpgsql(EnvironmentConstants.DatabaseConnectionString())
                        .UseSnakeCaseNamingConvention()
            )
            .AddDatabaseDeveloperPageExceptionFilter();
#endif
        services.AddTransient<IDatabaseSeeder, DefaultsSeeder>();

        if (!addRandomDataSeeder)
            return services;

        services.AddTransient<IDatabaseSeeder, RandomDataSeeder>();
        services.AddTransient<IEntitySeeder<Organization>, RandomOrganizationSeeder>();
        services.AddTransient<IEntitySeeder<Challenge>, RandomChallengeSeeder>();
        services.AddTransient<IEntitySeeder<Sector>, RandomSectorSeeder>();
        services.AddTransient<IEntitySeeder<Comment>, RandomCommentSeeder>();
        return services;
    }
}
