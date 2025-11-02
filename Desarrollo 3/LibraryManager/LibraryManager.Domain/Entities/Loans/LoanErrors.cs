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
    }
}
