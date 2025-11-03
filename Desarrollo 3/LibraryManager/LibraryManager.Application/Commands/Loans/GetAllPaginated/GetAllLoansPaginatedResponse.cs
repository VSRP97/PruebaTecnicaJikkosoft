using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Loans.GetAllPaginated
{
    public class GetAllLoansPaginatedResponse
    {
        public IReadOnlyList<GetLoanResponse> Loans { get; set; }
        public int TotalCount { get; set; }
    }

    public class GetLoanResponse
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public string BookTitle { get; set; }
        public Guid MemberId { get; set; }
        public string MemberName { get; set; }
        public DateTime? LoanDate { get; set; }
        public DateTime? ExpectedReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
