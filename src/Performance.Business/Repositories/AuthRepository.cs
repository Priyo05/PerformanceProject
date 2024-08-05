using Microsoft.EntityFrameworkCore;
using Performance.Business.Interfaces;
using Performance.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance.Business.Repositories;
public class AuthRepository : IAuthRepository
{
    private readonly PerformancedbContext _context;

    public AuthRepository(PerformancedbContext context)
    {
        _context = context;
    }

    //public void RegisterProfile(Profile profile)
    //{
    //    _context.Profiles.Add(profile);
    //    _context.SaveChanges();
    //}

    //public void RegisterUser(User user)
    //{
    //    _context.Users.Add(user);
    //    _context.SaveChanges();
    //}

    public User GetAccount(string username)
    {
        return _context.Users.FirstOrDefault(x => x.Username.Equals(username))
            ?? throw new KeyNotFoundException("Username belum terdaftar");
    }

    public Role GetRoleByUsername(int roleID)
    {

        return _context.Roles.FirstOrDefault(c => c.Id == roleID);
    }

}

