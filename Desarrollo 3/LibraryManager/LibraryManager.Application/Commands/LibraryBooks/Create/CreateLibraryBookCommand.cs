using LibraryManager.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.LibraryBooks.Create
{
    public sealed record CreateLibraryBookCommand(
        Guid LibraryId,
        Guid BookId,
        int TotalCopies,
        int AvailableCopies) : ICommand<Guid>;
}
