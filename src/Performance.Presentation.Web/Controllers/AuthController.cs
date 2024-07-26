using Microsoft.AspNetCore.Mvc;
using Performance.Presentation.Web.Services;

namespace Performance.Presentation.Web.Controllers;

[Route("Auth")]
public class AuthController : Controller
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }


    [HttpGet("Login")]
    public IActionResult Login()
    {
        return View();
    }


}

