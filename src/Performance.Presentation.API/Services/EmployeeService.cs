using Performance.Business.Interfaces;
using Performance.Business.Repositories;
using Performance.DataAccess.Models;
using Performance.Presentation.API.ViewModels.Employee;

namespace Performance.Presentation.API;
public class EmployeeService
{
    private readonly IEmployeeRespository _employeeRespository;

    public EmployeeService(IEmployeeRespository employeeRespository, IReportMainIndicatorRepository reportRepository)
    {
        _employeeRespository = employeeRespository;
    }

    public Profile GetUser(string name, string nik, string department)
    {
        var profile = _employeeRespository.GetUser(name, nik, department);

        return profile; 
    }

    public EmployeeIndexViewModel GetAll(string? search, int pageNumber, int pageSize)
    {
        List<EmployeeViewModel> employeeViewModels;

        employeeViewModels = _employeeRespository.GetAll(search, pageNumber, pageSize)
            .Select(c => new EmployeeViewModel
            {
                EmployeeId = c.UserId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Nik = c.Nik,
                Department = c.Department,
            }).ToList();


        int totalemployees = _employeeRespository.CountEmployees(search);

        return new EmployeeIndexViewModel
        {
            Employees = employeeViewModels,
            Search = search,
            PagenationInfo = new PagenationInfo
            {
                PageSize = pageSize,
                PageNumber = pageNumber,
                TotalItems = totalemployees
            }
        };

    }


    public User Insert(InsertEmployeeViewModel registerViewModel)
    {

        long val;
        if(!(long.TryParse(registerViewModel.NIK,out val)))
        {
            throw new Exception("NIK must be a number");
        }

        Profile profile = new Profile
        {
            Title = registerViewModel.Title,
            FirstName = registerViewModel.Firstname,
            LastName = registerViewModel.Lastname,
            Nik = registerViewModel.NIK,
            Department = registerViewModel.Department,
            Birthdate = registerViewModel.Birthdate,
            Email = registerViewModel.Firstname + "." + registerViewModel.Lastname + "@indocyber.co.id"
        };

        _employeeRespository.InsertProfile(profile);

        User user = new User
        {
            Username = registerViewModel.Firstname + "." + registerViewModel.Lastname,
            Password = BCrypt.Net.BCrypt.HashPassword("Indocyber"),
            Role = 2,
            ProfileId = profile.UserId,
            CreatedAt = DateTime.Now
        };

        return _employeeRespository.InsertUser(user);

    }


    public UpdateEmployeeViewModel GetById(int id)
    {
        var profile = _employeeRespository.GetById(id);

        return new UpdateEmployeeViewModel
        {
            Id = profile.UserId,
            Firstname = profile.FirstName,
            Lastname = profile.LastName,
            Department = profile.Department,
            NIK = profile.Nik,
            Birthdate = (DateTime)profile.Birthdate,
            Title = profile.Title,
        };
    }

    public UpdateEmployeeViewModel Update(int id,UpdateEmployeeViewModel viewModel)
    {
        var getUser = _employeeRespository.GetById(id);

        getUser.FirstName = viewModel.Firstname;
        getUser.LastName = viewModel.Lastname;
        getUser.Birthdate = viewModel.Birthdate;
        getUser.Department = viewModel.Department;
        getUser.Nik = viewModel.NIK;
        getUser.Title = viewModel.Title;

        var updated = _employeeRespository.Updated(getUser);

        return new UpdateEmployeeViewModel
        {
            Firstname = updated.FirstName,
            Lastname = updated.LastName,
            Department = updated.Department,
            NIK = updated.Nik,
            Birthdate = (DateTime)updated.Birthdate,
            Title = updated.Title,
        };

    }

    public Profile Delete(int id)
    {
        var user = _employeeRespository.GetById(id);

        var deleted = _employeeRespository.Delete(user);

        return deleted;
    }

}

