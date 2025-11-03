using LibraryManager.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Libraries.Delete
{
    public sealed record DeleteLibraryCommand(Guid Id) : ICommand;
}
