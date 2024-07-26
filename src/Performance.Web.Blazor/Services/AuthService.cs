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

    public AuthService(IAuthRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public void Register(RegisterViewModel registerViewModel)
    {

        if(registerViewModel.Department  == null)
        {
            throw new Exception("Data Tidak ada");
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

        User user = new User
        {
            Username = "Admin",
            Password = BCrypt.Net.BCrypt.HashPassword(registerViewModel.Password),
            Role = 1,
            CreatedAt = DateTime.Now
        };

        _accountRepository.Register(profile, user);

    }

    public AuthenticationTicket Login(LoginViewModel vm)
    {
        //Console.WriteLine(vm.Username);
        //var user = _accountRepository.GetAccount(vm.Username);


        ////var user = _Context.Accounts.FirstOrDefault(u => u.Username.Equals(vm.Username))
        ////    ?? throw new KeyNotFoundException("Username salah atau belum terdaftar");

        ////memverifikasi apakah password yang diinput(VM) benar dan cocok dengan yang ada di user
        //bool isCorrectPassword = BCrypt.Net.BCrypt.Verify(vm.Password, user.Password);

        //if (!isCorrectPassword)
        //{
        //    throw new PasswordException("Username atau Password anda salah");
        //}

        //var userRoles = _accountRepository.GetRolesByAccountId(user.Id);

        //if (!VerifyUserRole(user.Roles, vm.Role))
        //{
        //    throw new RoleException("Role tidak valid untuk pengguna ini");
        //}


        ////principal
        ClaimsPrincipal principal = GetPrincipal(vm);


        AuthenticationTicket authenticationTicket = GetAuthenticationTicket(principal);

        return authenticationTicket;
    }


    //private bool VerifyUserRole(IEnumerable<Role> userRoles, EnumRoles inputRole)
    //{
    //    // Memeriksa apakah inputRole ada dalam koleksi userRoles
    //    return userRoles.Any(r => r.Role1 == inputRole);
    //}

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

