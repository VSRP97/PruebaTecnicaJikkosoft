using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Loans.Delete
{
    public sealed class DeleteLoanCommandHandler : ICommandHandler<DeleteLoanCommand>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLoanCommandHandler(ILoanRepository loanRepository, IUnitOfWork unitOfWork)
        {
            _loanRepository = loanRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetById(request.Id, cancellationToken);

            if (loan is null)
                return Result.Failure(LoanErrors.NotFound);

            if (loan.Status != LoanStatus.Returned)
                return Result.Failure(LoanErrors.LoanNotReturned);

            _loanRepository.Delete(loan);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
