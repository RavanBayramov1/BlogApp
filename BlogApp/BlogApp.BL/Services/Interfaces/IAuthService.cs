using BlogApp.BL.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Interfaces;

public interface IAuthService
{
    Task RegisterAsync(RegisterDto dto);
    Task<string> LoginAsync(LoginDto dto);
}
