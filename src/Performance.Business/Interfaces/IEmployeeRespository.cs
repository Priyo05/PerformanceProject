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
    List<Profile> GetAll(string? search, int pageNumber, int pageSize);
    public int CountEmployees(string? search);
    Profile InsertProfile(Profile profile);
    User InsertUser(User user);
    Profile GetById(int id);
    Profile Updated(Profile profile);
    Profile Delete(Profile profile);
}

