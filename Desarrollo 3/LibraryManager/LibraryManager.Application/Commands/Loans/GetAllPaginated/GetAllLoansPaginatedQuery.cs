using LibraryManager.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Loans.GetAllPaginated
{
    public sealed record GetAllLoansPaginatedQuery(
        int skip,
        int limit,
        string? search,
        Guid? bookId,
        Guid? memberId) : IQuery<LoanPaginationResponse>;
}
