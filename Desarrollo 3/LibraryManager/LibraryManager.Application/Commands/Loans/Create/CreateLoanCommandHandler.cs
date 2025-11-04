using LibraryManager.Application.Abstractions.Clock;
using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.LibraryBooks;
using LibraryManager.Domain.Entities.Loans;
using LibraryManager.Domain.Entities.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Loans.Create
{
    internal sealed class CreateLoanCommandHandler : ICommandHandler<CreateLoanCommand, Guid>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly ILibraryBookRepository _libraryBookRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateLoanCommandHandler(ILoanRepository loanRepository, IUnitOfWork unitOfWork, ILibraryBookRepository libraryBookRepository, IMemberRepository memberRepository, IDateTimeProvider dateTimeProvider)
        {
            _loanRepository = loanRepository;
            _unitOfWork = unitOfWork;
            _libraryBookRepository = libraryBookRepository;
            _memberRepository = memberRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result<Guid>> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var libraryBook = await _libraryBookRepository.GetById(request.LibraryBookId, cancellationToken);
            if (libraryBook is null)
                return Result.Failure<Guid>(LibraryBookErrors.NotFound);

            var member = await _memberRepository.GetById(request.MemberId, cancellationToken);
            if (member is null)
                return Result.Failure<Guid>(MemberErrors.NotFound);

            if (libraryBook.AvailableCopies < request.LoanQuantity)
                return Result.Failure<Guid>(LibraryBookErrors.InsufficientStock);

            var loan = Loan.Create(request.LibraryBookId, request.MemberId, _dateTimeProvider.UtcNow);

            _loanRepository.Add(loan);

            var result = loan.MarkAsLoaned(_dateTimeProvider.UtcNow, request.ExpectedReturnDate, request.LoanQuantity);

            if (result.IsFailure)
                return Result.Failure<Guid>(result.Error);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return loan.Id;
        }
    }
}
