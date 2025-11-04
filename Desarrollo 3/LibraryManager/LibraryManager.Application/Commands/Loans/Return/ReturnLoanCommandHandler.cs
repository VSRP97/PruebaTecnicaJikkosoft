using LibraryManager.Application.Abstractions.Clock;
using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Loans.Return
{
    internal sealed class ReturnLoanCommandHandler : ICommandHandler<ReturnLoanCommand, string>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ReturnLoanCommandHandler(ILoanRepository loanRepository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
        {
            _loanRepository = loanRepository;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result<string>> Handle(ReturnLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetById(request.Id, cancellationToken);

            if (loan is null)
                return Result.Failure<string>(LoanErrors.NotFound);

            var result = loan.MarkAsReturned(_dateTimeProvider.UtcNow, request.ReturnQuantity);

            if (result.IsFailure)
                return Result.Failure<string>(result.Error);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(loan.Status.ToString());
        }
    }
}
