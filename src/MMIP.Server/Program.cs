using MMIP.Infrastructure.Extensions;
using MMIP.Server.Extensions;
using Duende.IdentityServer.Services;
using MMIP.Infrastructure.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity();
builder.Services.AddTransient<IProfileService, UserService>();

//Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddDatabase(false);
builder.Services.AddEntityServices();
builder.Services.AddRepositories();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<IdentityOptions>(
    options => options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier
);

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

//app.UseAuthentication();
//app.UseAuthorization();
//app.UseIdentityServices();

app.MapControllers();

await app.Initialize(true);

app.Run();
