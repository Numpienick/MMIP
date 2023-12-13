using Duende.IdentityServer.AspNetIdentity;
using Duende.IdentityServer.Configuration;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Authentication;
using MMIP.Infrastructure.Context;
using MMIP.Infrastructure.Models.Identity;
using MMIP.Infrastructure.Seeders;
using MMIP.Infrastructure.Seeders.EntitySeeders;
using Microsoft.EntityFrameworkCore;
using MMIP.Application.Interfaces;
using MMIP.Shared.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

    // TODO: Inhoud is questionable, fix -> work in progress
    internal static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services
            .AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationContext>();

        services.AddIdentityServer().AddApiAuthorization<AppUser, ApplicationContext>();

        services.AddAuthentication().AddIdentityServerJwt();

        return services;
        //services
        //    .AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false) //was true
        //    .AddEntityFrameworkStores<ApplicationContext>();

        //services.AddIdentityServer(options =>
        //    {
        //    options.Discovery.CustomEntries.Add("local_api", "~/api");
        //    options.UserInteraction = new UserInteractionOptions()
        //        {
        //            LoginUrl = "/login",
        //            LogoutUrl = "/logout",
        //            LoginReturnUrlParameter = "returnUrl"
        //        };
        //    }).AddApiAuthorization<AppUser, ApplicationContext>(options =>
        //        {
        //            options.IdentityResources["openid"].UserClaims.Add("name");
        //            options.ApiResources.Single().UserClaims.Add("name");
        //            options.IdentityResources["openid"].UserClaims.Add("role");
        //            options.ApiResources.Single().UserClaims.Add("role");
        //        });

        //services.Configure<IdentityOptions>(options =>
        //    options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);
        //services.AddAuthentication().AddIdentityServerJwt();
        //services.AddTransient<IProfileService, ProfileService<AppUser>>();

        //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role");

        //return services;
    }
}
