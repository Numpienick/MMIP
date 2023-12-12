using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MMIP.Infrastructure.Context;
using MMIP.Test.Infrastructure.Extensions;

namespace MMIP.Test.Infrastructure.Fixtures;

public class ContextFixture : IDisposable
{
    private const string ConnectionString =
        "Host=localhost;Port=6543;Database=mmip_db_temp;Username=mmip;Password=mmip123;Include Error Detail=true";

    private readonly ServiceProvider _provider;

    public ContextFixture()
    {
        var services = new ServiceCollection();

        services.AddDatabase(ConnectionString);
        services.AddEntityServices();
        services.AddRepositories();

        _provider = services.BuildServiceProvider();

        InitializeDatabase();
    }

    public T GetRequiredService<T>()
    {
        return _provider.GetRequiredService<T>();
    }

    private void InitializeDatabase()
    {
        DatabaseContainerController.InitializeDockerContainer();
        var canConnect = DatabaseContainerController.CanConnectToContainer(ConnectionString);
        if (!canConnect)
        {
            throw new Exception("Cannot connect to test database");
        }

        var contextFactory = GetContextFactory();
        using var context = contextFactory.CreateDbContext();
        context.Database.EnsureCreated();
    }

    public IDbContextFactory<ApplicationContext> GetContextFactory() =>
        _provider.GetRequiredService<IDbContextFactory<ApplicationContext>>();

    public void Dispose()
    {
        DatabaseContainerController.DisposeDockerContainer();
    }
}
