using BlogApp.BL.DTOs.Options;
using BlogApp.BL.ExternalService.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.ExternalService.Implements
{
    public class JwtTokenHandler : IJwtTokenHandler
    {
        readonly JwtOptions opt;
        public JwtTokenHAndler(IOptions<JwtOptions> _opt)
        {
            opt = _opt.Value;
        }
        public string CreateToken(User user, int hours = 36)
        {
            List<Claim> claims = [
            new Claim(ClaimTypes.Name,user.Username),
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.Role,user.Role.ToString()),
            new Claim(ClaimTypes.GivenName , user.Name + " " + user.Surname)
            ];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(opt.SecretKey));
            SigningCredentials cred = new(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken secToken = new(
                issuer: opt.Issuer,
                audience: opt.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(hours),
                signingCredentials: cred
                );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(secToken);
        }
    }
}
