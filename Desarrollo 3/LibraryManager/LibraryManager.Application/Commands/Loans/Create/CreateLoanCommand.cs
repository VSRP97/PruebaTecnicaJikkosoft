using LibraryManager.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Loans.Create
{
    public sealed record CreateLoanCommand(
        Guid LibraryBookId,
        Guid MemberId,
        int LoanQuantity,
        DateTime ExpectedReturnDate) : ICommand<Guid>;
}
