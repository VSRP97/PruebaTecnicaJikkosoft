using LibraryManager.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Members.GetAllPaginated
{
    public sealed record GetAllMemberPaginatedQuery(
        int Skip,
        int Limit,
        string? Search) : IQuery<GetAllMembersPaginatedResponse>;
}
