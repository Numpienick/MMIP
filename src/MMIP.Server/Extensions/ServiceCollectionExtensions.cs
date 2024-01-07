using MMIP.Infrastructure.Context;
using MMIP.Infrastructure.Seeders;
using MMIP.Infrastructure.Seeders.EntitySeeders;
using MMIP.Application.Interfaces;
using MMIP.Shared.Entities;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        services.AddTransient<IEntitySeeder<Comment>, RandomCommentSeeder>();
        return services;
    }

    internal static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services
            .AddIdentity<User, IdentityRole>(
                options => options.SignIn.RequireConfirmedAccount = false
            )
            .AddEntityFrameworkStores<ApplicationContext>();

        services
            .AddIdentityServer()
            .AddApiAuthorization<User, ApplicationContext>()
            .AddDeveloperSigningCredential();

        JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
        services.AddIdentityOptions();
        return services;
    }

    internal static IServiceCollection AddIdentityOptions(this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(options =>
        {
            // Password settings
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            // Lockout settings
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(1);
            options.Lockout.MaxFailedAccessAttempts = 10;
            options.Lockout.AllowedForNewUsers = true;

            // User settings
            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true; // default is false
        });

        services
            .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.LoginPath = "/Login";
                options.AccessDeniedPath = "/Error";
            });
        return services;
    }
}
