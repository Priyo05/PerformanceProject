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
}

