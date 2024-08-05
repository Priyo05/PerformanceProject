using Performance.Business.Interfaces;
using Performance.DataAccess.Models;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Performance.Presentation.API.ViewModels.Auth;

namespace Performance.Presentation.API;
public class AuthService
{
    private readonly IAuthRepository _accountRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IAuthRepository accountRepository, IConfiguration configuration)
    {
        _accountRepository = accountRepository;
        _configuration = configuration;
    }

    //public void Register(RegisterEmployeeViewModel registerViewModel)
    //{

    //    Profile profile = new Profile
    //    {
    //        Title = registerViewModel.Title,
    //        FirstName = registerViewModel.Firstname,
    //        LastName = registerViewModel.Lastname,
    //        Nik = registerViewModel.NIK,
    //        Department = registerViewModel.Department,
    //        Birthdate = registerViewModel.Birthdate,
    //        Email = registerViewModel.Firstname + "." + registerViewModel.Lastname + "@indocyber.co.id"
    //    };

    //    _accountRepository.RegisterProfile(profile);

    //    User user = new User
    //    {
    //        Username = registerViewModel.Firstname+"."+registerViewModel.Lastname,
    //        Password = BCrypt.Net.BCrypt.HashPassword("Indocyber"),
    //        Role = 2,
    //        ProfileId = profile.UserId,
    //        CreatedAt = DateTime.Now
    //    };

    //    _accountRepository.RegisterUser(user);

    //}

    //public void RegisterAdm(RegisterViewModel registerViewModel)
    //{

    //    if (registerViewModel.Department == null)
    //    {
    //        throw new Exception("Data Tidak ada");
    //    }

    //    Profile profile = new Profile
    //    {
    //        UserId = registerViewModel.Id,
    //        Title = registerViewModel.Title,
    //        FirstName = registerViewModel.Firstname,
    //        LastName = registerViewModel.Lastname,
    //        Nik = registerViewModel.NIK,
    //        Department = registerViewModel.Department,
    //        Birthdate = registerViewModel.Birthdate,
    //        Email = registerViewModel.Firstname + "." + registerViewModel.Lastname + "@indocyber.co.id"
    //    };

    //    _accountRepository.RegisterProfile(profile);

    //    User user = new User
    //    {
    //        Username = "Admin",
    //        Password = BCrypt.Net.BCrypt.HashPassword(registerViewModel.Password),
    //        Role = 1,
    //        ProfileId = profile.UserId,
    //        CreatedAt = DateTime.Now
    //    };

    //    _accountRepository.RegisterUser(user);

    //}

    public TokenRespondDto Login(LoginViewModel vm)
    {
        var user = _accountRepository.GetAccount(vm.Username);
        
        bool isCorrectPassword = BCrypt.Net.BCrypt.Verify(vm.Password, user.Password);

        if (!isCorrectPassword)
        {
            throw new Exception("Username atau Password anda salah");
        }

        var userRoles = _accountRepository.GetRoleByUsername((int)user.Role);

        if (userRoles.Name != vm.Role)
        {
            throw new Exception("Role tidak valid untuk user ini");
        }


        var algorithm = SecurityAlgorithms.HmacSha256;

        var payload = new List<Claim>
        {
            new Claim("username", user.Username),
            new Claim(ClaimTypes.Role,vm.Role)
        };

        var signature = _configuration.GetSection("AppSettings:TokenSignature").Value;
        var encodedSignature = Encoding.UTF8.GetBytes(signature);

        var Token = new JwtSecurityToken
        (
            claims: payload,
            expires: DateTime.Now.AddHours(12),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(encodedSignature), algorithm)
        );

        var serializeToken = new JwtSecurityTokenHandler().WriteToken(Token);

        return new TokenRespondDto
        {
            Token = serializeToken
        };
    }



}

