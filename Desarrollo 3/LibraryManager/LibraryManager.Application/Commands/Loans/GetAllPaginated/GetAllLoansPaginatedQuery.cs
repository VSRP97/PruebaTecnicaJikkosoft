using LibraryManager.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Loans.GetAllPaginated
{
    public record GetAllLoansPaginatedQuery(
        int Skip,
        int Limit,
        string? Search,
        string? Status,
        Guid? BookId,
        Guid? MemberId) : IQuery<GetAllLoansPaginatedResponse>;
}
