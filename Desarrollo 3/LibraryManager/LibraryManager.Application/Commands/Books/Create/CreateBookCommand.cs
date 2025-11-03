using LibraryManager.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Books.Create
{
    public sealed record CreateBookCommand(
        string ISBN,
        string Title,
        string Author,
        int PublicationYear) : ICommand<Guid>;
}
