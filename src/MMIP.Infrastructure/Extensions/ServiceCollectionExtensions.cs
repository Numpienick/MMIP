using Microsoft.Extensions.DependencyInjection;
using MMIP.Application.Interfaces.Repositories;
using MMIP.Infrastructure.Repositories;
using MMIP.Infrastructure.Services;

namespace MMIP.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityServices(this IServiceCollection services)
    {
        return services
            .AddTransient<ChallengeService>()
            .AddTransient<CommentService>()
            .AddTransient<OrganizationService>();
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddTransient(typeof(IDataRepository<>), typeof(DataRepository<>))
            .AddTransient<IUnitOfWork, UnitOfWork>()
            .AddTransient<IChallengeRepository, ChallengeRepository>();
    }
}
