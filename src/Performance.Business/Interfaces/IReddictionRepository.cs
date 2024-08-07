using Performance.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance.Business.Interfaces;
public interface IReddictionRepository
{
    Additionalindicator GetReddictionUser(int userid, int periode);
    List<Indicator> GetReddictionDetail(int reddictionId);
    Indicator Insert(Indicator indicator);
    Indicator GetIndicator(int id);
    Indicator UpdatedIndicator(Indicator indicator);
}

