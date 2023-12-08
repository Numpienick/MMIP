using MMIP.Infrastructure.Services;
using MMIP.Infrastructure.Repositories;
using MMIP.Shared.Entities;
using MMIP.Server.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddTransient<IRepository<Comment>, CommentRepository>();
builder.Services.AddTransient<IRepository<Challenge>, ChallengeRepository>();
builder.Services.AddTransient<IRepository<Tag>, TagRepository>();
builder.Services.AddTransient<TagRepository>(s => (TagRepository)s.GetService<IRepository<Tag>>());
builder.Services.AddTransient<ChallengeService>();
builder.Services.AddTransient<TagService>();
builder.Services.AddTransient<CommentService>();

builder.Services.AddDatabase(false);

// TODO: Move to a method in ServiceCollectionExtensions (and probably make transient)

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

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

await app.Initialize(false);

app.Run();
