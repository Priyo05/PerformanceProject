using Performance.Business.Interfaces;
using Performance.DataAccess.Models;
using Performance.Web.Blazor.ViewModels;

namespace Performance.Web.Blazor.Services;
public class EmployeeService
{
    private readonly IEmployeeRespository _employeeRespository;

    public EmployeeService(IEmployeeRespository employeeRespository)
    {
        _employeeRespository = employeeRespository;
    }

    public Profile GetUser(string name, string nik, string department)
    {
        return _employeeRespository.GetUser(name,nik, department);
    }

}

