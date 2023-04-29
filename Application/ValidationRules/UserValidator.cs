using Domain.Entities;
using FluentValidation;

namespace Application.ValidationRules;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
    }
}