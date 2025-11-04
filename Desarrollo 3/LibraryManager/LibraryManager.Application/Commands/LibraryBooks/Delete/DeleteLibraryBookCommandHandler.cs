using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.LibraryBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.LibraryBooks.Delete
{
    internal sealed class DeleteLibraryBookCommandHandler : ICommandHandler<DeleteLibraryBookCommand>
    {
        private readonly ILibraryBookRepository _libraryBookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLibraryBookCommandHandler(ILibraryBookRepository libraryBookRepository, IUnitOfWork unitOfWork)
        {
            _libraryBookRepository = libraryBookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteLibraryBookCommand request, CancellationToken cancellationToken)
        {
            var libraryBook = await _libraryBookRepository.GetById(request.Id, cancellationToken);

            if (libraryBook is null)
                return Result.Failure(LibraryBookErrors.NotFound);

            _libraryBookRepository.Delete(libraryBook);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
