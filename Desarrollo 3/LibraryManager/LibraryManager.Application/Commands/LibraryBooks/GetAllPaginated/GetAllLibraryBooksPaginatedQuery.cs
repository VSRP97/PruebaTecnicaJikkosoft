using LibraryManager.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.LibraryBooks.GetAllPaginated
{
    public sealed record GetAllLibraryBooksPaginatedQuery(
        int Skip,
        int Limit,
        string? Search) : IQuery<GetAllLibraryBooksPaginatedResponse>;
}
