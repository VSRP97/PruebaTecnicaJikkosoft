using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Books;
using LibraryManager.Domain.Entities.LibraryBooks;
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
            Guid libraryBookId,
            Guid memberId,
            LoanStatus status,
            DateTime createdAt)
        {
            Id = id;
            LibraryBookId = libraryBookId;
            MemberId = memberId;
            Status = status;
            LoanedAmount = 0;
            CreatedAt = createdAt;
        }
        private Loan()
        {
        }


        public Guid Id { get; private set; }
        public Guid LibraryBookId { get; private set; }
        public Guid MemberId { get; private set; }
        public DateTime? LoanDate { get; private set; }
        public DateTime? ExpectedReturnDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }
        public LoanStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int LoanedAmount { get; private set; }

        #region Navigation
        public LibraryBook LibraryBook { get; private set; }
        public Member Member { get; set; }
        #endregion

        public static Loan Create(
            Guid libraryBookId,
            Guid memberId,
            DateTime utcNow)
        {
            var loan = new Loan(
                Guid.NewGuid(),
                libraryBookId,
                memberId,
                LoanStatus.Created,
                utcNow);

            return loan;
        }

        public Result MarkAsLoaned(DateTime loanDate, DateTime expectedReturnDate, int quantity = 1)
        {
            if (Status != LoanStatus.Created)
                return Result.Failure(LoanErrors.NotCreatedStatus);

            if (expectedReturnDate <= loanDate)
                return Result.Failure(LoanErrors.ExpectedReturnDateLessOrEqualToLoanDate);

            var result = LibraryBook.LendCopies(quantity);
            if (result.IsFailure)
                return result;

            LoanedAmount = quantity;
            Status = LoanStatus.Loaned;            
            LoanDate = loanDate;
            ExpectedReturnDate = expectedReturnDate;

            return Result.Success();
        }

        public Result MarkAsReturned(DateTime returnDate, int quantity = 1)
        {
            if (Status != LoanStatus.Loaned)
                return Result.Failure(LoanErrors.NotLoanedStatus);

            if (LoanedAmount - quantity < 0)
                return Result.Failure(LoanErrors.ReturnsGreaterThanLoaned);

            var result = LibraryBook.ReturnCopies(quantity);
            if (result.IsFailure)
                return result;            

            LoanedAmount -= quantity;
            ReturnDate = returnDate;

            if (LoanedAmount == 0)
                Status = LoanStatus.Returned;

            return Result.Success();
        }
    }
}
