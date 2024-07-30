using Performance.Business.Interfaces;
using Performance.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Performance.Business.Repositories;
public class ReportRepository : IReportRepository
{
    private readonly PerformancedbContext _context;

    public ReportRepository(PerformancedbContext context)
    {
        _context = context;
    }

    public Workmainindicator GetMainIndicatorReport(int userId,int periode)
    {
        var mainReport = _context.Workmainindicators
        .Where(c =>
              (c.UserId == userId) &&
              (c.Period == periode))
                .FirstOrDefault();


        if (mainReport == null)
        {
            throw new Exception("Report belum ada, apa mau buat report");
        }

        return mainReport;
    }

}

