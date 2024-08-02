using Performance.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance.Business.Interfaces;
public interface IReportMainIndicatorRepository
{
    public void CreateReport(Workmainindicator workmainindicator,Basiccompetence basiccompetence, Responsibilityareaindicator responsibilityareaindicator, Additionalindicator additionalindicator);
    public void CreateReportAnnualyTable(Anuallycompetence anuallycompetence);
    List<Workmainindicator> GetAllMainIndicatorByUser(int periode, int userid);
    Workmainindicator GetMainIndicatorById(int id);
    Workmainindicator Updated(Workmainindicator workmainindicator);
    Anuallycompetence GetAnuallyCompetence(int userid, int periode);
    Workmainindicator InsertMainIndicator(Workmainindicator resutl);
    Workmainindicator DeleteMainIndicator(Workmainindicator getmainIndicator);
}

