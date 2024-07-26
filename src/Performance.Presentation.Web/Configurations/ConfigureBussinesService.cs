using Performance.Business.Interfaces;
using Performance.Business.Repositories;

namespace Performance.Presentation.Web.Configurations;
public static class ConfigureBussinesService
{
    public static IServiceCollection AddBussinesServices(this IServiceCollection services)
    {

        services.AddScoped<IAuthRepository, AuthRepository>();

        return services;
    }
}

