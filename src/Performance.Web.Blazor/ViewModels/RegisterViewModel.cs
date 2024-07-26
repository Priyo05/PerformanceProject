using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Security;

namespace Performance.Web.Blazor.ViewModels;
public class RegisterViewModel
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    [MaxLength(16)]
    public string NIK { get; set; }
    public string Department { get; set; }
    public string Title { get; set; }
    public DateTime Birthdate { get; set; }
    public string Password { get; set; }
    [Compare("Password",ErrorMessage ="Password not match")]
    public string RetypePassword {  get; set; }
}

     