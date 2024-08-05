namespace Performance.Presentation.API.ViewModels.Employee;
public class EmployeeIndexViewModel
{
    public List<EmployeeViewModel> Employees { get; set; }
    public PagenationInfo PagenationInfo { get; set; }
    public string? Search { get; set; }

}

