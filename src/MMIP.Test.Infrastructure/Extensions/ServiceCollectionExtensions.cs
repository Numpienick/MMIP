using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MMIP.Application.Interfaces.Repositories;
using MMIP.Infrastructure.Context;
using MMIP.Infrastructure.Repositories;
using MMIP.Infrastructure.Services;

namespace MMIP.Test.Infrastructure.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddDatabase(
        this IServiceCollection services,
        string connectionString
    )
    {
        return services.AddDbContextFactory<ApplicationContext>(
            opt =>
                opt.UseNpgsql(connectionString)
                    .UseSnakeCaseNamingConvention()
                    .EnableSensitiveDataLogging()
        );
    }

    internal static IServiceCollection AddEntityServices(this IServiceCollection services)
    {
        return services
            .AddTransient<ChallengeService>()
            .AddTransient<CommentService>()
            .AddTransient<OrganizationService>();
    }

    internal static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddTransient(typeof(IDataRepository<>), typeof(DataRepository<>))
            .AddTransient<IUnitOfWork, UnitOfWork>()
            .AddTransient<IChallengeRepository, ChallengeRepository>();
    }
}
