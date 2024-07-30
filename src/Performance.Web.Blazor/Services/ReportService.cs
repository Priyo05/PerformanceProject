using Performance.Business.Interfaces;
using Performance.DataAccess.Models;

namespace Performance.Web.Blazor.Services;
public class ReportService
{
    private readonly IReportRepository _reportRepository;

    public ReportService(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public Workmainindicator GetMainIndicatorReport(int userid, int periode)
    {
        return _reportRepository.GetMainIndicatorReport(userid,periode);
    }

}

