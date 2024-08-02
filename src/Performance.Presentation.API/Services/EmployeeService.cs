using Performance.Business.Interfaces;
using Performance.Business.Repositories;
using Performance.DataAccess.Models;

namespace Performance.Presentation.API;
public class EmployeeService
{
    private readonly IEmployeeRespository _employeeRespository;
    private readonly IReportMainIndicatorRepository _reportRepository;

    public EmployeeService(IEmployeeRespository employeeRespository, IReportMainIndicatorRepository reportRepository)
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

