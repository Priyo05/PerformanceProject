using Performance.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance.Business.Interfaces;
public interface IAuthRepository
{
    public void RegisterProfile(Profile profile);
    public void RegisterUser(User user);
    public User GetAccount(string username);
    public Role GetRoleByUsername(int roleId);

}
