using MMIP.Infrastructure.Extensions;
using MMIP.Server.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity();

//Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddDatabase(false);
builder.Services.AddEntityServices();
builder.Services.AddRepositories();
builder.Services.AddAutoMapperProfiles();

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

app.UseIdentityServices();

app.MapControllers();

await app.Initialize(false);

app.Run();
