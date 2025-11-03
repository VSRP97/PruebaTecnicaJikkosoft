using LibraryManager.Application.Abstractions.Data;
using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Loans.GetAllPaginated
{
    internal class GetAllLoansPaginatedQueryHandler
        : IQueryHandler<GetAllLoansPaginatedQuery, GetAllLoansPaginatedResponse>
    {
        private readonly ILoanRepository _loanRepository;

        public GetAllLoansPaginatedQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public Task<Result<GetAllLoansPaginatedResponse>> Handle(GetAllLoansPaginatedQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
