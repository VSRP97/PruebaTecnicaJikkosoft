using LibraryManager.Domain.Entities.Loans;

namespace LibraryManager.Application.Commands.Loans.GetById
{
    public class GetLoanByIdResponse
    {
        public Guid Id { get; set; }
        public Guid LibraryBookId { get; set; }
        public Guid MemberId { get; set; }
        public DateTime? LoanDate { get; set; }
        public DateTime? ExpectedReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int LoanedAmount { get; set; }
    }
}