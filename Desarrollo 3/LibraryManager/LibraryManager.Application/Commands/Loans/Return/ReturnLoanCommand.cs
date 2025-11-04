using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Entities.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Loans.Return
{
    public sealed record ReturnLoanCommand(Guid Id, int ReturnQuantity) : ICommand<string>;
}
