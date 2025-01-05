using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Interfaces;

public interface IUserService 
{
    Task<string> CreateAsync();
    Task DeleteAsync(string username);

}
