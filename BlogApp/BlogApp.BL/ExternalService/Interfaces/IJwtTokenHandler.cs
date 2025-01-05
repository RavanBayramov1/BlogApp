using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.ExternalService.Interfaces;

public interface IJwtTokenHandler
{
    string CreateToken(User user, int hours=36);
}
