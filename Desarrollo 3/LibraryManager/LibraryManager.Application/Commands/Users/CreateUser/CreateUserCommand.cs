using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LibraryManager.Application.Abstractions.Messaging;

namespace LibraryManager.Application.Commands.Users.CreateUser
{
    public record CreateUserCommand(
        string FirstName,
        string? SecondName,
        string LastName,
        string? SecondLastName,
        string Email) : ICommand<Guid>;
}
