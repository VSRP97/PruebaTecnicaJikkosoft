using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Books;
using LibraryManager.Domain.Entities.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities.Loans
{
    public sealed class Loan : Entity
    {
        private Loan(
            Guid id,
            Guid bookId,
            Guid memberId,
            LoanStatus status,
            DateTime createdAt) : base(id)
        {
            BookId = bookId;
            MemberId = memberId;
            Status = status;
            CreatedAt = createdAt;
        }
        private Loan()
        {
        }

        public Guid BookId { get; private set; }
        public Guid MemberId { get; private set; }
        public DateTime? LoanDate { get; private set; }
        public DateTime? ExpectedReturnDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }
        public LoanStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        #region Navigation
        public Book Book { get; set; }
        public Member Member { get; set; }
        #endregion

        public static Loan Create(
            Guid bookId,
            Guid memberId,
            DateTime utcNow)
        {
            var loan = new Loan(
                Guid.NewGuid(),
                bookId,
                memberId,
                LoanStatus.Created,
                utcNow);

            return loan;
        }

        public Result MarkAsLoaned(DateTime loanDate, DateTime expectedReturnDate)
        {
            if (Status != LoanStatus.Created)
                return Result.Failure(LoanErrors.NotCreatedStatus);

            var result = Book.LendCopies();
            if (result.IsFailure)
                return result;

            Status = LoanStatus.Loaned;            
            LoanDate = loanDate;
            ExpectedReturnDate = expectedReturnDate;

            return Result.Success();
        }

        public Result MarkAsReturned(DateTime returnDate)
        {
            if (Status != LoanStatus.Loaned)
                return Result.Failure(LoanErrors.NotLoanedStatus);

            var result = Book.ReturnCopies();
            if (result.IsFailure)
                return result;

            ReturnDate = returnDate;
            Status = LoanStatus.Returned;

            return Result.Success();
        }
    }
}
