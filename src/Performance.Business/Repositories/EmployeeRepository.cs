using Performance.Business.Interfaces;
using Performance.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance.Business.Repositories;
public class EmployeeRepository : IEmployeeRespository
{
    private readonly PerformancedbContext _performancedbContext;

    public EmployeeRepository(PerformancedbContext performancedbContext)
    {
        _performancedbContext = performancedbContext;
    }


    public Profile GetUser(string name, string nik, string department)
    {
        var user = _performancedbContext.Profiles
                        .Where(c =>
                            (string.IsNullOrEmpty(name) || (c.FirstName + " " + c.LastName).Contains(name)) &&
                            (string.IsNullOrEmpty(nik) || c.Nik == nik) &&
                            (string.IsNullOrEmpty(department) || c.Department == department))
                        .FirstOrDefault();

        if (user == null)
        {
            throw new Exception("User tidak ada");
        }

        return user;
    }
}

