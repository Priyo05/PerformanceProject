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

    public async Task Register(Profile profile,User user)
    {
        _context.Users.Add(user);
        _context.Profiles.Add(profile);
        _context.SaveChanges();
    }

}

