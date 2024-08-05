using Microsoft.EntityFrameworkCore;
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

    public List<Profile> GetAll(string? search, int pageNumber, int pageSize)
    {
        var query = from employee in _performancedbContext.Profiles
                    join user in _performancedbContext.Users on employee.UserId equals user.ProfileId
                    join role in _performancedbContext.Roles on user.Role equals role.Id
                    where((search == null) ||
                           (employee.FirstName.Contains(search))||
                           (employee.LastName.Contains(search))||
                           (employee.Department.Contains(search))) &&
                           (role.Name == "Employee")
                           select new Profile
                           {
                               UserId = employee.UserId,
                               FirstName = employee.FirstName,
                               LastName = employee.LastName,
                               Nik = employee.Nik,
                               Department = employee.Department,
                           };


        return query
               .Skip((pageNumber - 1)* pageSize)
               .Take(pageSize)
               .ToList();
    }


    public int CountEmployees(string? search)
    {
        var query = from employee in _performancedbContext.Profiles
                    join user in _performancedbContext.Users on employee.UserId equals user.ProfileId
                    join role in _performancedbContext.Roles on user.Role equals role.Id
                    where ((search == null) ||
                           (employee.FirstName.Contains(search)) ||
                           (employee.LastName.Contains(search)) ||
                           (employee.Department.Contains(search))) &&
                           (role.Name == "Employee")
                    select employee;

        return query.Count();
    }

    public Profile InsertProfile(Profile profile)
    {
        _performancedbContext.Profiles.Add(profile);
        _performancedbContext.SaveChanges();
        return profile;
    }

    public User InsertUser(User user)
    {
        _performancedbContext.Users.Add(user);
        _performancedbContext.SaveChanges();
        return user;
    }

    public Profile GetById(int id)
    {
        return _performancedbContext.Profiles.FirstOrDefault(c => c.UserId == id) ??
            throw new Exception("Id Not found");
    }

    public Profile Updated(Profile profile)
    {
        _performancedbContext.Update(profile);
        _performancedbContext.SaveChanges();
        return profile;
    }
    
    public Profile Delete(Profile profile)
    {
        var user = _performancedbContext.Users.FirstOrDefault(c => c.ProfileId.Equals(profile.UserId));

        _performancedbContext.Remove(user);
        _performancedbContext.Remove(profile);
        _performancedbContext.SaveChanges();
        return profile;
    }

}

