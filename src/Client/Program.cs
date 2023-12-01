using Client;
using Client.Controllers;
using Shared.StateContainers;
using Environment;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Identity;
using MudBlazor.Services;
using Shared.Contexts;
using MudBlazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddLocalization();

builder.Services.AddMudServices();
builder.Services.AddScoped<ProtectedSessionStorage>(); //Dependency injection
builder.Services.AddIdentityCore<IdentityUser>().AddEntityFrameworkStores<ChallengeContext>();
;

//builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped(
    _ => new HttpClient { BaseAddress = new Uri(EnvironmentConstants.ApiUrl) }
);
builder.Services.AddScoped<RequestController>();

builder.Services.AddSingleton<Snackbar>();

// TODO: Remove when database access is available.
builder.Services.AddSingleton<TempStateContainer>();
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;

    config.SnackbarConfiguration.PreventDuplicates = true;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});
await builder.Build().RunAsync();
