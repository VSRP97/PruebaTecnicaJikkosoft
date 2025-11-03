using LibraryManager.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Books.Update
{
    public sealed record UpdateBookCommand(
        Guid Id,
        string? Title,
        string? Author,
        int? PublicationYear) : ICommand;
}
