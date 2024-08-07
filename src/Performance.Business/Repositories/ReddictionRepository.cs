using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Performance.Business.Interfaces;
using Performance.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance.Business.Repositories;
public class ReddictionRepository : IReddictionRepository
{
    private readonly PerformancedbContext _context;

    public ReddictionRepository(PerformancedbContext context)
    {
        _context = context;
    }

    public Additionalindicator GetReddictionUser(int userid, int periode)
    {
        return _context.Additionalindicators.FirstOrDefault(c => c.UserId.Equals(userid) && c.Period.Equals(periode)) ??
            throw new Exception("Id not available");
    }

    public List<Indicator> GetReddictionDetail(int reddictionId)
    {
        var query = from indicator in _context.Indicators
                    where indicator.Additionalindicator.Equals(reddictionId)
                    select indicator;


        return query.ToList();
    }

    public Indicator Insert(Indicator indicator)
    {
        using var transaction = _context.Database.BeginTransaction();

        try
        {
            _context.Indicators.Add(indicator);

            _context.SaveChanges();

            Additionalindicator additionalindicator = _context.Additionalindicators
                .FirstOrDefault(c => c.Id.Equals(indicator.Additionalindicator));


            int totalValue = (int)_context.Indicators
                .Where(i => i.Additionalindicator.Equals(indicator.Additionalindicator))
                .Sum(i => i.Value);

            additionalindicator.IndikatorTotalValue = totalValue;

            _context.Additionalindicators.Update(additionalindicator);

            _context.SaveChanges();

            transaction.Commit();

            return indicator;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public Indicator GetIndicator(int id)
    {
        return _context.Indicators.FirstOrDefault(c => c.Id.Equals(id)) ??
            throw new Exception("Id not available");
    }

    public Indicator UpdatedIndicator(Indicator indicator)
    {
        Additionalindicator additionalindicator = _context.Additionalindicators.FirstOrDefault(c => c.Id.Equals(indicator.Additionalindicator));

        int totalValue = (int)_context.Indicators
        .Where(i => i.Additionalindicator.Equals(indicator.Additionalindicator))
        .Sum(i => i.Value);

        additionalindicator.IndikatorTotalValue = totalValue;

        _context.Additionalindicators.Update(additionalindicator);
        _context.Indicators.Update(indicator);
        _context.SaveChanges();
        return indicator;
    }

}

