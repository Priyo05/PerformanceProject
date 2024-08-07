using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Performance.Web.Blazorwasm;
using Performance.Web.Blazorwasm.Shared.Providers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("API", options =>
{
    options.BaseAddress = new Uri("https://localhost:7058/");
}).AddHttpMessageHandler<CustomHttpHandler>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider,CustomAuthProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomHttpHandler>();

await builder.Build().RunAsync();
