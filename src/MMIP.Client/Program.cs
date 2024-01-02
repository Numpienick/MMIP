using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MMIP.Client;
using MMIP.Client.Controllers;
using MMIP.Client.Extensions;
using MMIP.Environment;
using MudBlazor;
using MudBlazor.Services;
using MMIP.Shared.Contexts;
using MMIP.Shared.Entities;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddLocalization();

builder.Services.AddMudServices();

// Was IdentityUser. TODO: check if IdentityUser is replaced with User somewhere in the project
builder.Services.AddIdentityCore<User>().AddEntityFrameworkStores<ChallengeContext>();

builder.Services.AddScoped(
    _ => new HttpClient { BaseAddress = new Uri(EnvironmentConstants.ApiUrl) }
);
builder.Services.AddScoped<RequestController>();
builder.Services.AddTransient<ValueValidator>();

builder.Services.AddSingleton<Snackbar>();

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;

    config.SnackbarConfiguration.PreventDuplicates = true;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});
await builder.Build().RunAsync();
