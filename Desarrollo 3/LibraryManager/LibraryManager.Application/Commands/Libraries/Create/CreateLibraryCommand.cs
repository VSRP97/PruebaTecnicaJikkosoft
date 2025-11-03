using LibraryManager.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManager.Application.Commands.Libraries.Create
{
    public sealed record CreateLibraryCommand(
        string Name) : ICommand<Guid>;
}
