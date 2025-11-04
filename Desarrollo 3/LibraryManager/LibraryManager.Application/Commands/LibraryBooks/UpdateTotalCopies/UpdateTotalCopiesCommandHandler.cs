using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.LibraryBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.LibraryBooks.UpdateTotalCopies
{
    internal sealed class UpdateTotalCopiesCommandHandler : ICommandHandler<UpdateTotalCopiesCommand>
    {
        private readonly ILibraryBookRepository _libraryBookRepo;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTotalCopiesCommandHandler(ILibraryBookRepository libraryBookRepo, IUnitOfWork unitOfWork)
        {
            _libraryBookRepo = libraryBookRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateTotalCopiesCommand request, CancellationToken cancellationToken)
        {
            var libraryBook = await _libraryBookRepo.GetById(request.Id, cancellationToken);

            if (libraryBook is null)
                return Result.Failure(LibraryBookErrors.NotFound);

            var result =  libraryBook.UpdateTotalCopies(request.CopyAmount);

            if (result.IsFailure)
                return Result.Failure(result.Error);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
