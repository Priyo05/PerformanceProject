using Performance.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance.Business.Interfaces;
public interface IEmployeeRespository
{
    Profile GetUser(string name, string nik, string department);
}

