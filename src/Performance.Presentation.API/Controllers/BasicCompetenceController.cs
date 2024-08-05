using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Performance.Presentation.API.Services;
using Performance.Presentation.API.ViewModels.BasicCompetence;
using Performance.Presentation.API.ViewModels.MainIndicatorAppraisal;

namespace Performance.Presentation.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BasicCompetenceController : ControllerBase
{
    private readonly EmployeeService _employeeService;
    private readonly BasicCompetenceService _basicCompetenceService;

    public BasicCompetenceController(EmployeeService employeeService, BasicCompetenceService basicCompetenceService)
    {
        _employeeService = employeeService;
        _basicCompetenceService = basicCompetenceService;
    }

    [HttpGet("/GetBasicCompetenceUser")]
    public IActionResult GetBasicCompetenceUser(int userid, int periode)
    {
        try
        {
            var basicCompetence = _basicCompetenceService.BasicCompetenceUser(userid, periode);

            return Ok(basicCompetence);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("/InsertBasicCompetence")]
    public IActionResult Insert(BasicCompetenceViewModel viewModel, int userid, int periode)
    {
        try
        {
            var insert = _basicCompetenceService.InsertBasicComtence(viewModel, userid, periode);

            return Ok(insert);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

