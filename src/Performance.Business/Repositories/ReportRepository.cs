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

    public void CreateReportAnnualyTable(Anuallycompetence anuallycompetence)
    {
        
        _context.Anuallycompetences.Add(anuallycompetence);
        _context.SaveChanges();
    }

    public void CreateReport(Workmainindicator workmainindicator, Basiccompetence basiccompetence, Responsibilityareaindicator responsibilityareaindicator, Additionalindicator additionalindicator)
    {
        _context.Workmainindicators.Add(workmainindicator);
        _context.Basiccompetences.Add(basiccompetence);
        _context.Responsibilityareaindicators.Add(responsibilityareaindicator);
        _context.Additionalindicators.Add(additionalindicator);

        _context.SaveChanges();

    }

    public List<Workmainindicator> GetAllMainIndicatorByUser(int periode, int userid)
    {
        var query = from work in _context.Workmainindicators
                    where (work.UserId == userid) &&
                    (work.Period == periode)
                    select work;
        Console.WriteLine("ngitung ada brpa "+ query.Count());

        return query.ToList();
    }

    public Workmainindicator GetMainIndicatorById(int id)
    {
        return _context.Workmainindicators.FirstOrDefault(c => c.Id.Equals(id)) ??
            throw new Exception("Id WorkMainIndikator Not Available");
    }

    public Workmainindicator Updated(Workmainindicator workmainindicator)
    {
        _context.Workmainindicators.Update(workmainindicator);
        _context.SaveChanges();
        return workmainindicator;
    }

}

