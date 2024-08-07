using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using Performance.Presentation.API.ViewModels.MainIndicatorAppraisal;

namespace Performance.Presentation.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class ReportMainIndicatorController : ControllerBase
{
    private readonly ReportMainIndicatorService _reportService;
    private readonly EmployeeService _employeeService;

    public ReportMainIndicatorController(ReportMainIndicatorService reportService, EmployeeService employeeService)
    {
        _reportService = reportService;
        _employeeService = employeeService;
    }

    [HttpGet("/GetUser")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetUser(string name,string nik, string department)
    {
        try
        {
            var user = _employeeService.GetUser(name,nik,department);

            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("/GetAllMainIndicatorUser")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetMainIndicatorUser(int userid, int periode)
    {
        try
        {
            var allmainIndicator = _reportService.GetAllMainIndicatorByUser(periode, userid);

            return Ok(allmainIndicator);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("/CreateReport/{userid}/{periode}")]
    [Authorize(Roles = "Admin")]
    public IActionResult CreateReport(int userid, int periode)
    {
        try
        {
            _reportService.CreateReport(userid, periode);
            return Ok("Succes Create Report");
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("/GetMainIndicatorById/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetMainIndicatorById(int id)
    {
        try
        {
            var mainIndicator = _reportService.GetMainIndicatorById(id);
            return Ok(mainIndicator);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("/InsertMainIndicator/{userid}/{periode}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Insert(MainIndikatorViewModel viewModel,int userid,int periode)
    {
        try
        {
            var insert = _reportService.CreateMainIndikator(viewModel, userid, periode);

            return Created(" ", insert);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("/UpdateMainIndicator/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateMainIndicator(int id, MainIndikatorViewModel model)
    {
        try
        {
            var updated = _reportService.EditMainIndicator(id, model);

            return Ok(updated);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("/DeleteMainIndicator/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteMainIndicator(int id)
    {
        try
        {
            var delete = _reportService.DeleteMainIndicator(id);
            return Ok(delete);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


}

