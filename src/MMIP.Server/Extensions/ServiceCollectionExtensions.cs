using MMIP.Infrastructure.Context;
using MMIP.Infrastructure.Seeders;
using MMIP.Infrastructure.Seeders.EntitySeeders;
using MMIP.Application.Interfaces;
using MMIP.Shared.Entities;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;

namespace MMIP.Server.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddDatabase(
        this IServiceCollection services,
        bool addRandomDataSeeder = false
    )
    {
        services.AddDbContext<ApplicationContext>().AddDatabaseDeveloperPageExceptionFilter();

        services.AddTransient<IDatabaseSeeder, DefaultsSeeder>();

        if (!addRandomDataSeeder)
            return services;

        services.AddTransient<IDatabaseSeeder, RandomDataSeeder>();
        services.AddTransient<IEntitySeeder<Organization>, RandomOrganizationSeeder>();
        services.AddTransient<IEntitySeeder<Challenge>, RandomChallengeSeeder>();
        services.AddTransient<IEntitySeeder<Sector>, RandomSectorSeeder>();
        return services;
    }

    internal static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services
            .AddIdentity<User, IdentityRole>(
                options => options.SignIn.RequireConfirmedAccount = true
            )
            .AddEntityFrameworkStores<ApplicationContext>();

        services
            .AddIdentityServer()
            .AddApiAuthorization<User, ApplicationContext>()
            .AddDeveloperSigningCredential();

        JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
        return services;
    }
}
