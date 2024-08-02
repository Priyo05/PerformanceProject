using Performance.Business.Interfaces;
using Performance.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Performance.Business.Repositories;
public class ReportMainIndicatorRepository : IReportMainIndicatorRepository
{
    private readonly PerformancedbContext _context;

    public ReportMainIndicatorRepository(PerformancedbContext context)
    {
        _context = context;
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
        
        if (!query.Any())
        {
            throw new Exception("Report belum ada");
        }

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

    public Anuallycompetence GetAnuallyCompetence(int userid, int periode)
    {
        return _context.Anuallycompetences.FirstOrDefault(c => c.Period.Equals(periode) && c.UserId.Equals(userid)) ??
            throw new Exception("AnnuallyReport Not found");
    }

    public Workmainindicator InsertMainIndicator(Workmainindicator resutl)
    {
        _context.Workmainindicators.Add(resutl);
        _context.SaveChanges();
        return resutl;
    }

    public Workmainindicator DeleteMainIndicator(Workmainindicator workmainindicator)
    {
        _context.Workmainindicators.Remove(workmainindicator);
        _context.SaveChanges();
        return workmainindicator;
    }

}

