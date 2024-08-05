namespace Performance.Presentation.API;
public class PagenationInfo
{
    public int TotalItems { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int TotalPages
    {
        get
        {
            return (int)Math.Ceiling((double)TotalItems / PageSize);
        }
    }
}

