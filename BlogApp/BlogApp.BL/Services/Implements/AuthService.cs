using AutoMapper;
using BlogApp.BL.DTOs.UserDtos;
using BlogApp.BL.Exceptions.Common;
using BlogApp.BL.ExternalService.Interfaces;
using BlogApp.BL.Helpers;
using BlogApp.BL.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Implements;

public class AuthService(IUserRepository _repo, IMapper _mapper,IJwtTokenHandler _tokenHandler) : IAuthService
{
    public async Task<string> LoginAsync(LoginDto dto)
    {
        User? user = null;
        if (dto.UsernameOrEmail.Contains('@'))
        {
            user = await _repo.GetAll().Where(x =>x.Email == dto.UsernameOrEmail).FirstOrDefaultAsync();
        }
        else
        {
            user = await _repo.GetAll().Where(x => x.Username == dto.UsernameOrEmail).FirstOrDefaultAsync();
        }
        if (user == null)
            throw new NotFoundException<User>();
        if (!HashHelper.VerifyHashedPassword(user.PasswordHash, dto.Password))
            throw new NotFoundException<User>();

        return _tokenHandler.CreateToken(user,36);

    }

    public async Task RegisterAsync(RegisterDto dto)
    {
        var user = await _repo.GetAll().Where(x=>x.Username == dto.Username || x.Email == dto.Email).FirstOrDefaultAsync();
        if (user != null)
        {
            if (user.Email == dto.Email) 
                throw new ExistException<User>("Email already using by another user!");
            else if (user.Username == dto.Username)
                throw new ExistException<User>("Username already using by another user!");
        }
        user = _mapper.Map<User>(dto);
        await _repo.AddAsync(user);
        await _repo.SaveAsync();
    }
}
