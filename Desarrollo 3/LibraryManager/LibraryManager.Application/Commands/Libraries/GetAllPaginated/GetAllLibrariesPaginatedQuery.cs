using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Application.Commands.Loans.GetAllPaginated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Libraries.GetAllPaginated
{
    public sealed record GetAllLibrariesPaginatedQuery(
        int Skip,
        int Limit,
        string? Search) : IQuery<GetAllLibrariesPaginatedResponse>;
}
