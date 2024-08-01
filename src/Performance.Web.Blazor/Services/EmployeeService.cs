using Performance.Business.Interfaces;
using Performance.Business.Repositories;
using Performance.DataAccess.Models;
using Performance.Web.Blazor.ViewModels;

namespace Performance.Web.Blazor.Services;
public class EmployeeService
{
    private readonly IEmployeeRespository _employeeRespository;
    private readonly IReportRepository _reportRepository;

    public EmployeeService(IEmployeeRespository employeeRespository, IReportRepository reportRepository)
    {
        _employeeRespository = employeeRespository;
        _reportRepository = reportRepository;
    }

    public Profile GetUser(string name, string nik, string department)
    {
        var profile = _employeeRespository.GetUser(name, nik, department);

        return profile; 
    }

}

