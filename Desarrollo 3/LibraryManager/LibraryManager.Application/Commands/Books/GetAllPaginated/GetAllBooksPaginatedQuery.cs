using LibraryManager.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Books.GetAllPaginated
{
    public sealed record GetAllBooksPaginatedQuery(
        int Skip,
        int Limit,
        string? Search) : IQuery<GetAllBooksPaginatedResponse>;
}
