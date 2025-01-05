using BlogApp.BL.DTOs.UserDtos;
using BlogApp.Core.Entities;
using BlogApp.Core.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Validators.UserValidators;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    readonly IUserRepository _repo;
    public RegisterDtoValidator(IUserRepository repo)
    {
        _repo = repo;
        RuleFor(x => x.Username)
            .NotEmpty()
            .NotNull()
            .Must(Username => !Username.Contains('@'))
            .WithMessage("Username can't contain '@' character!");
            //.Must(x => _repo.GetByUserNameAsync(x).Result == null)
            //.WithMessage("Username is exists!");
        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();
        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(8)
            .WithMessage("The password must contain at least 8 elements!");
        RuleFor(x=>x.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(32);
        RuleFor(x => x.Surname)
            .NotEmpty()
            .NotNull()
            .MaximumLength(64);

    }
}
