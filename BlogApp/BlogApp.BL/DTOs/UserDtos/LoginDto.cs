using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.DTOs.UserDtos;

public class LoginDto
{
    public string UsernameOrEmail { get; set; }
    public string Password { get; set; }
}
