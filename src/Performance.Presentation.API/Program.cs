using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Performance.DataAccess;
using Performance.Presentation.API;
using Performance.Presentation.API.Services;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IServiceCollection services = builder.Services;

Dependencies.ConfigureServices(builder.Configuration, services);

services.AddBussinesService();

services.AddScoped<AuthService>();
services.AddScoped<EmployeeService>();
services.AddScoped<ReportMainIndicatorService>();
services.AddScoped<BasicCompetenceService>();
services.AddScoped<ReddictionService>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        builder.Configuration.GetSection("AppSettings:TokenSignature").Value
                    ))
        });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
        options =>
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Description = "Standar auth header using the bearer scheme",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            options.OperationFilter<SecurityRequirementsOperationFilter>();
        }
    );

var allowedSpecificOrigin = "_performance";

builder.Services.AddCors(options
    => options
    .AddPolicy(name: allowedSpecificOrigin,
               policy => policy.WithOrigins("https://localhost:7145")
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                               .AllowCredentials())
    );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowedSpecificOrigin);
app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
