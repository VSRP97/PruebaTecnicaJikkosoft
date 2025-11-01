using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace LibraryManager.Application.Commands.Users.CreateUser
{
    internal sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(c => c.FirstName)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(c => c.SecondName)
                .MaximumLength(50);

            RuleFor(c => c.LastName)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(c => c.SecondLastName)
                .MaximumLength(50);
        }
    }
}
