using Environment;
using Infrastructure.Context;
using Infrastructure.Seeders;
using Infrastructure.Seeders.EntitySeeders;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace Server.Extensions;

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
        if (!addRandomDataSeeder)
            return services;

        services.AddTransient<IDatabaseSeeder, RandomDataSeeder>();
        services.AddTransient<IEntitySeeder<Organization>, OrganizationSeeder>();
        services.AddTransient<IEntitySeeder<Challenge>, ChallengeSeeder>();
        return services;
    }
}
