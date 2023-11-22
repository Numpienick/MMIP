using Client;
using Client.StateContainers;
using Environment;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();
builder.Services.AddScoped(
    sp => new HttpClient { BaseAddress = new Uri(EnvironmentConstants.ApiUrl) }
);
builder.Services.AddLocalization();

// TODO: Remove when database access is available.
builder.Services.AddSingleton<TempStateContainer>();
builder.Services.AddMudServices();
await builder.Build().RunAsync();
