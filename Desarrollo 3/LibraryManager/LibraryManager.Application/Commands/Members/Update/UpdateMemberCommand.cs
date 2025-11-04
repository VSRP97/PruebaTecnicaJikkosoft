using LibraryManager.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Members.Update
{
    public sealed record UpdateMemberCommand(
        Guid Id,
        string? Name,
        string? Email) : ICommand;
}
