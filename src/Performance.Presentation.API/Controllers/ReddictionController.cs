using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Performance.Presentation.API.Services;
using Performance.Presentation.API.ViewModels.ReductionAdditionAppraisal;

namespace Performance.Presentation.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReddictionController : ControllerBase
{
    private readonly ReddictionService _reddictionService;

    public ReddictionController(ReddictionService reddictionService)
    {
        _reddictionService = reddictionService;
    }

    [HttpGet("/GetReddictionuser")]
    public IActionResult GetReddictionuser(int userid, int periode)
    {
        try
        {
            var reddiction = _reddictionService.GetReddictionUser(userid, periode);
            
            return Ok(reddiction);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("/InsertReddiction")]
    public IActionResult InsertReddiction(ReddictionViewModel viewModel,int userid, int periode)
    {
        try
        {
            var reddiction = _reddictionService.InsertReddiction(viewModel,userid, periode);

            return Ok(reddiction);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("/UpdateIndicator")]
    public IActionResult UpdateIndicator(List<ReddictionViewModel> viewModel)
    {
        try
        {
            _reddictionService.UpdateReddiction(viewModel);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}

