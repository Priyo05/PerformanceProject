using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Performance.Business.Interfaces;
using Performance.DataAccess.Models;
using System.Security.Claims;
using System.Security.Principal;
using Performance.Web.Blazor.ViewModels;

namespace Performance.Web.Blazor.Services;
public class AuthService
{
    private readonly IAuthRepository _accountRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthService(IAuthRepository accountRepository, IHttpContextAccessor httpContextAccessor)
    {
        _accountRepository = accountRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public void Register(RegisterEmployeeViewModel registerViewModel)
    {

        if(registerViewModel == null)
        {
            throw new Exception("Data Tidak ada");
        }

        Profile profile = new Profile
        {
            UserId = registerViewModel.Id,
            Title = registerViewModel.Title,
            FirstName = registerViewModel.Firstname,
            LastName = registerViewModel.Lastname,
            Nik = registerViewModel.NIK,
            Department = registerViewModel.Department,
            Birthdate = registerViewModel.Birthdate,
            Email = registerViewModel.Firstname + "." + registerViewModel.Lastname + "@indocyber.co.id"
        };

        _accountRepository.RegisterProfile(profile);

        User user = new User
        {
            Username = registerViewModel.Firstname+"."+registerViewModel.Lastname,
            Password = BCrypt.Net.BCrypt.HashPassword("Indocyber"),
            Role = 2,
            ProfileId = profile.UserId,
            CreatedAt = DateTime.Now
        };

        _accountRepository.RegisterUser(user);

    }

    public void RegisterAdm(RegisterViewModel registerViewModel)
    {

        if (registerViewModel.Department == null)
        {
            throw new Exception("Data Tidak ada");
        }

        Profile profile = new Profile
        {
            UserId = registerViewModel.Id,
            Title = registerViewModel.Title,
            FirstName = registerViewModel.Firstname,
            LastName = registerViewModel.Lastname,
            Nik = registerViewModel.NIK,
            Department = registerViewModel.Department,
            Birthdate = registerViewModel.Birthdate,
            Email = registerViewModel.Firstname + "." + registerViewModel.Lastname + "@indocyber.co.id"
        };

        _accountRepository.RegisterProfile(profile);

        User user = new User
        {
            Username = "Admin",
            Password = BCrypt.Net.BCrypt.HashPassword(registerViewModel.Password),
            Role = 1,
            ProfileId = profile.UserId,
            CreatedAt = DateTime.Now
        };

        _accountRepository.RegisterUser(user);

    }

    public async Task Login(LoginViewModel vm)
    {
        var user = _accountRepository.GetAccount(vm.Username);

        bool isCorrectPassword = BCrypt.Net.BCrypt.Verify(vm.Password, user.Password);

        if (!isCorrectPassword)
        {
            throw new Exception("Username atau Password anda salah");
        }

        var userRoles = _accountRepository.GetRoleByUsername((int)user.Role);

        if(userRoles.Name != vm.Role)
        {
            throw new Exception("Role tidak valid untuk user ini");
        }


        ////principal
        ClaimsPrincipal principal = GetPrincipal(vm);


        AuthenticationTicket authenticationTicket = GetAuthenticationTicket(principal);

        await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

    }

    public ClaimsPrincipal GetPrincipal(LoginViewModel user)
    {
        var claim = new List<Claim>
        {
            new Claim("username", user.Username),
            new Claim(ClaimTypes.Role,user.Role.ToString())
        };

        ClaimsIdentity identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

        return new ClaimsPrincipal(identity);
    }

    public AuthenticationTicket GetAuthenticationTicket(ClaimsPrincipal principal)
    {
        AuthenticationProperties authenticationProperties = new AuthenticationProperties
        {
            IssuedUtc = DateTime.Now,
            ExpiresUtc = DateTime.Now.AddMinutes(20),
            AllowRefresh = false
        };

        AuthenticationTicket authenticationTicket = new AuthenticationTicket(principal, authenticationProperties,
                                                            CookieAuthenticationDefaults.AuthenticationScheme);

        return authenticationTicket;
    }


}

