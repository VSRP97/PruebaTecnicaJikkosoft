using LibraryManager.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Members.Create
{
    public sealed record CreateMemberCommand(
        string Name,
        string Email) : ICommand<Guid>;
}
