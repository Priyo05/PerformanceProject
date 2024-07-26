using Performance.Business.Interfaces;
using Performance.Business.Repositories;

namespace Performance.Web.Blazor.Configurations;
public static class ConfigureBussinesService
{
    public static IServiceCollection AddBussinesService(this IServiceCollection services)
    {

        services.AddScoped<IAuthRepository, AuthRepository>();
        
        return services;
    }
}

