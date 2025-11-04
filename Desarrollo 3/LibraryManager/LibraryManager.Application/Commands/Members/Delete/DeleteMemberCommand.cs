using LibraryManager.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Members.Delete
{
    public sealed record DeleteMemberCommand(Guid Id) : ICommand;
}
