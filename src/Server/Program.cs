using Environment;
using Infrastructure.Context;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Add services to the container.
builder.Services.AddControllers();

#if DEBUG
builder.Services.AddDbContextFactory<ApplicationContext>(
    opt =>
        opt.UseNpgsql(EnvironmentConstants.DatabaseConnectionString())
            .UseSnakeCaseNamingConvention()
            .EnableSensitiveDataLogging()
);
#else
builder.Services.AddDbContextFactory<ApplicationContext>(
    opt =>
        opt.UseNpgsql(EnvironmentConstants.DatabaseConnectionString).UseSnakeCaseNamingConvention()
);
#endif

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddSingleton<ChallengeService>();
builder.Services.AddSingleton<CommentService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var contextFactory = services.GetRequiredService<IDbContextFactory<ApplicationContext>>();
    var context = await contextFactory.CreateDbContextAsync();
    await context.Database.EnsureCreatedAsync();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
