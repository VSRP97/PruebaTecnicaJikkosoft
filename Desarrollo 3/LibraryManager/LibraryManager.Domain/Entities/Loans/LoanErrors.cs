using LibraryManager.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities.Loans
{
    public static class LoanErrors
    {
        public static readonly Error NotCreatedStatus = new(
            "Loan.NotCreatedStatus",
            "This operation is invalid for loans not in 'Created' status.");

        public static readonly Error NotLoanedStatus = new(
            "Loan.NotLoanedStatus",
            "This operation is invalid for loans not in 'Loaned' status.");

        public static readonly Error ReturnsGreaterThanLoaned = new(
            "Loan.ReturnsGreaterThanLoaned",
            "The number of returns cannot be greater than the number of loaned items.");

        public static readonly Error ExpectedReturnDateLessOrEqualToLoanDate = new(
            "Loan.ExpectedReturnDateLessOrEqualToLoanDate",
            "The expected return date must be greater than the loan date.");

        public static readonly Error NotFound = new(
            "Loan.NotFound",
            "The loan with the specified identifier was not found.");

        public static readonly Error LoanNotReturned = new(
            "Loan.LoanNotReturned",
            "The loan has not been fully returned yet.");
    }
}
