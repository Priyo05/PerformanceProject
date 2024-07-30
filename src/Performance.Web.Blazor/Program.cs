using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Performance.DataAccess;
using Performance.Web.Blazor.Components;
using Performance.Web.Blazor.Configurations;
using Performance.Web.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


IServiceCollection services = builder.Services;

Dependencies.ConfigureServices(builder.Configuration, services);

services.AddBussinesService();

services.AddScoped<AuthService>();
services.AddScoped<EmployeeService>();
services.AddScoped<ReportService>();

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "Auth_token";
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/access-denied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

//services.AddScoped<AuthenticationStateProvider, RevalidatingServerAuthenticationStateProvider<AuthenticationState>>();
services.AddAuthorization();
services.AddHttpContextAccessor();
services.AddCascadingAuthenticationState();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
