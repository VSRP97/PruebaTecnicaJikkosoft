using LibraryManager.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.LibraryBooks.UpdateTotalCopies
{
    public sealed record UpdateTotalCopiesCommand(
        Guid Id,
        int CopyAmount) : ICommand;
}
