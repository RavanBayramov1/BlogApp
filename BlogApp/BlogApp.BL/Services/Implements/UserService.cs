using BlogApp.BL.Services.Interfaces;
using BlogApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Implements;

public class UserService : IUserService
{
    public Task<string> CreateAsync()
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string username)
    {
        throw new NotImplementedException();
    }
}
