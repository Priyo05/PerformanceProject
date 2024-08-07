using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Performance.Presentation.API.ViewModels.Employee;

namespace Performance.Presentation.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class EmployeeController : ControllerBase
{
    private EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetAll(string? search,int pageNumber = 1)
    {
        int pageSize = 5;
        var vm = _employeeService.GetAll(search, pageNumber, pageSize);

        return Ok(vm);
    }


    [HttpPost("AddEmployee")]
    [Authorize(Roles = "Admin")]
    public IActionResult Insert(InsertEmployeeViewModel viewModel)
    {
        try
        {
            var inserted = _employeeService.Insert(viewModel);

            return Ok(inserted);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetById(int id)
    {
        if (id < 0)
        {
            return BadRequest();
        }

        var profile = _employeeService.GetById(id);

        return Ok(profile);
    }

    [HttpPut("{id}")]
    [Authorize(Roles ="Admin")]
    public IActionResult Update(int id, UpdateEmployeeViewModel viewModel)
    {
        try
        {
            var Update = _employeeService.Update(id, viewModel);

            return Ok(Update);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(int id)
    {
        try
        {
            var delete = _employeeService.Delete(id);
            return Ok(delete);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }




}

