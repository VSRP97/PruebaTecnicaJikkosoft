using LibraryManager.Application.Abstractions.Clock;
using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Books.Create
{
    internal sealed class CreateBookCommandHandler : ICommandHandler<CreateBookCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookRepository _bookRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateBookCommandHandler(IUnitOfWork unitOfWork, IBookRepository bookRepository, IDateTimeProvider dateTimeProvider)
        {
            _unitOfWork = unitOfWork;
            _bookRepository = bookRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result<Guid>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = Book.Create(
                request.ISBN,
                request.Title,
                request.Author,
                request.PublicationYear,
                _dateTimeProvider.UtcNow);

            _bookRepository.Add(book);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return book.Id;
        }
    }
}
