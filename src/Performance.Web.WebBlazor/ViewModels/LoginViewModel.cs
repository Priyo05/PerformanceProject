using System.ComponentModel.DataAnnotations;

namespace Performance.Web.WebBlazor.ViewModels;
public class LoginViewModel
{
    [Required(ErrorMessage ="Username is Required")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Password is Required")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Role is Required")]
    public string Role { get; set; }
}

