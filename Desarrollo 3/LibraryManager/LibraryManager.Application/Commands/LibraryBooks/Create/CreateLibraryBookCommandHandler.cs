using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Books;
using LibraryManager.Domain.Entities.Libraries;
using LibraryManager.Domain.Entities.LibraryBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.LibraryBooks.Create
{
    internal sealed class CreateLibraryBookCommandHandler : ICommandHandler<CreateLibraryBookCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILibraryRepository _libraryRepository;
        private readonly ILibraryBookRepository _libraryBookRepository;
        private readonly IBookRepository _bookRepository;

        public CreateLibraryBookCommandHandler(
            IUnitOfWork unitOfWork,
            ILibraryRepository libraryRepository,
            ILibraryBookRepository libraryBookRepository,
            IBookRepository bookRepository)
        {
            _unitOfWork = unitOfWork;
            _libraryRepository = libraryRepository;
            _libraryBookRepository = libraryBookRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Result<Guid>> Handle(CreateLibraryBookCommand request, CancellationToken cancellationToken)
        {
            var library = await _libraryRepository.GetById(request.LibraryId, cancellationToken);
            if (library is null)
                return Result.Failure<Guid>(LibraryErrors.NotFound);

            var book = await _bookRepository.GetById(request.BookId, cancellationToken);
            if (book is null)
                return Result.Failure<Guid>(BookErrors.NotFound);

            var libraryBookExists = await _libraryBookRepository.GetByLibraryAndBookIds(request.LibraryId, request.BookId, cancellationToken);

            if (libraryBookExists is not null)
                return Result.Failure<Guid>(LibraryBookErrors.Exists);

            var libraryBook = LibraryBook.Create(
                request.LibraryId,
                request.BookId,
                request.TotalCopies,
                request.AvailableCopies);

            _libraryBookRepository.Add(libraryBook);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return libraryBook.Id;
        }
    }
}
