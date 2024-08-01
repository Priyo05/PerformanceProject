using Performance.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance.Business.Interfaces;
public interface IReportRepository
{
    Workmainindicator GetMainIndicatorReport(int userid,int periode);
    public void CreateReport(Workmainindicator workmainindicator,Basiccompetence basiccompetence, Responsibilityareaindicator responsibilityareaindicator, Additionalindicator additionalindicator);
    public void CreateReportAnnualyTable(Anuallycompetence anuallycompetence);
    List<Workmainindicator> GetAllMainIndicatorByUser(int periode, int userid);
    Workmainindicator GetMainIndicatorById(int id);
    Workmainindicator Updated(Workmainindicator workmainindicator);

}

