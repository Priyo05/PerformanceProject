using System.ComponentModel.DataAnnotations;

namespace Performance.Web.WebBlazor.ViewModels.MainIndicatorAppraisal;
public class EmployeeSearchViewModel
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "NIK is required")]
    public string NIK { get; set; }
    [Required(ErrorMessage = "Department is required")]
    public string Department { get; set; }
    [Required(ErrorMessage = "Periode is required")]
    public int Periode { get; set; }

}

