namespace Performance.Web.WebBlazor.ViewModels.Employee;
public class EmployeeResponse
{
    public List<EmployeeViewModel> Employees { get; set; }
    public PagenationInfo PaginationInfo { get; set; }
    public string? Search { get; set; }
}

