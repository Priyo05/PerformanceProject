using Performance.Business.Interfaces;
using Performance.Business.Repositories;

namespace Performance.Presentation.API;
public static class ConfigureBussinesService
{
    public static IServiceCollection AddBussinesService(this IServiceCollection services)
    {

        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IEmployeeRespository, EmployeeRepository>();
        services.AddScoped<IReportMainIndicatorRepository, ReportMainIndicatorRepository>();
        services.AddScoped<IBasicCompetenceRepository, BasicCompetenceRespository>();


        return services;
    }
}

