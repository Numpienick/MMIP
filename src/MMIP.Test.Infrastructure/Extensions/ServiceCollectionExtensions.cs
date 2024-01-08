using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MMIP.Application.Interfaces.Repositories;
using MMIP.Infrastructure.Repositories;
using MMIP.Infrastructure.Services;
using MMIP.Test.Infrastructure.Stubs;

namespace MMIP.Test.Infrastructure.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddDatabase(
        this IServiceCollection services,
        string connectionString
    )
    {
        return services.AddDbContextFactory<StubApplicationContext>(
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
            .AddTransient(typeof(IDataRepository<>), typeof(StubDataRepository<>))
            .AddTransient<IUnitOfWork, StubUnitOfWork>()
            .AddTransient<IChallengeRepository, ChallengeRepository>();
    }
}
