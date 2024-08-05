using Performance.Business.Interfaces;
using Performance.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance.Business.Repositories;
public class BasicCompetenceRespository : IBasicCompetenceRepository
{
    private readonly PerformancedbContext _performancedbContext;

    public BasicCompetenceRespository(PerformancedbContext performancedbContext)
    {
        _performancedbContext = performancedbContext;
    }


    public Basiccompetence GetBasicCompetenceUser(int userid, int periode)
    {
        return _performancedbContext.Basiccompetences.FirstOrDefault(c => c.UserId.Equals(userid) && c.Period.Equals(periode))
            ?? throw new Exception("Report Belum ada");
    }

    public Basiccompetence Updated(Basiccompetence basiccompetence)
    {
        _performancedbContext.Update(basiccompetence);
        _performancedbContext.SaveChanges();
        return basiccompetence;
    }
}

