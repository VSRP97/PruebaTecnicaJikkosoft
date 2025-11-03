using LibraryManager.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Libraries.Update
{
    public sealed record UpdateLibraryCommand(Guid Id, string Name) : ICommand;
}
