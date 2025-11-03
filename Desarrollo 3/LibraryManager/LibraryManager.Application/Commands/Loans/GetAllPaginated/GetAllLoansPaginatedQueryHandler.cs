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
        private readonly ILoanRepository _loanRepo;

        public GetAllLoansPaginatedQueryHandler(ILoanRepository loanRepo)
        {
            _loanRepo = loanRepo;
        }

        public async Task<Result<GetAllLoansPaginatedResponse>> Handle(GetAllLoansPaginatedQuery request, CancellationToken cancellationToken)
        {
            var isParsed = Enum.TryParse(request.Status, out LoanStatus loanStatus);

            var result = await _loanRepo.GetAllLoansPaginated(
                request.Skip,
                request.Limit,
                request.Search,
                isParsed ? loanStatus : null,
                request.BookId,
                request.MemberId,
                cancellationToken);

            var loans = result.Item1.Select(l =>
            {
                return new GetLoanResponse()
                {
                    Id = l.Id,
                    BookId = l.LibraryBook.BookId,
                    BookTitle = l.LibraryBook.Book.Title,
                    LoanDate = l.LoanDate,
                    ExpectedReturnDate = l.ExpectedReturnDate,
                    MemberId = l.MemberId,
                    MemberName = l.Member.Name,
                    ReturnDate = l.ReturnDate,
                    Status = l.Status.ToString(),
                    CreatedAt = l.CreatedAt
                };
            });

            GetAllLoansPaginatedResponse response = new()
            {
                Loans = [.. loans],
                TotalCount = result.Item2
            };

            return response;
        }
    }
}
