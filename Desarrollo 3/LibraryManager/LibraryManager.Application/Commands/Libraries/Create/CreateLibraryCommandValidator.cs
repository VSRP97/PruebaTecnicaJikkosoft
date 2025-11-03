using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Libraries.Create
{
    internal sealed class CreateLibraryCommandValidator : AbstractValidator<CreateLibraryCommand>
    {
        public CreateLibraryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}
