using LibraryManager.Application.Abstractions.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Loans.GetById
{
    public sealed record GetLoanByIdQuery(Guid Id) : ICachedQuery<GetLoanByIdResponse>
    {
        public string CacheKey => $"loanId-{Id}";
        public TimeSpan? Expiration => null;
    }
}
