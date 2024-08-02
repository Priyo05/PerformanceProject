using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Performance.Presentation.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Login")]
    public IActionResult Login(LoginViewModel loginViewModel)
    {
        try
        {
            var auth = _authService.Login(loginViewModel);
            return Ok(auth);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("Register")]
    public IActionResult Register(RegisterEmployeeViewModel registerViewModel) 
    {
        try
        {
            _authService.Register(registerViewModel);

            return Ok("Register Success");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }



}

