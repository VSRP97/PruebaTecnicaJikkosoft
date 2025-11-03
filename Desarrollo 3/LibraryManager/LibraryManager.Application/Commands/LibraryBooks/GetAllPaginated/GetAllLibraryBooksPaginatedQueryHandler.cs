using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.LibraryBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.LibraryBooks.GetAllPaginated
{
    internal class GetAllLibraryBooksPaginatedQueryHandler
        : IQueryHandler<GetAllLibraryBooksPaginatedQuery, GetAllLibraryBooksPaginatedResponse>
    {
        private readonly ILibraryBookRepository _libraryBookRepo;

        public GetAllLibraryBooksPaginatedQueryHandler(ILibraryBookRepository libraryBookRepo)
        {
            _libraryBookRepo = libraryBookRepo;
        }

        public async Task<Result<GetAllLibraryBooksPaginatedResponse>> Handle(GetAllLibraryBooksPaginatedQuery request, CancellationToken cancellationToken)
        {
            var result = await _libraryBookRepo.GetAllLibraryBooksPaginated(
                request.Skip,
                request.Limit,
                request.Search);

            var libraryBooks = result.Item1.Select(lb =>
            {
                return new GetLibraryBookResponse()
                {
                    Id = lb.Id,
                    LibraryId = lb.LibraryId,
                    BookId = lb.BookId,
                    ISBN = lb.Book.ISBN,
                    Title = lb.Book.Title,
                    TotalCopies = lb.TotalCopies,
                    AvailableCopies = lb.AvailableCopies
                };
            });


            GetAllLibraryBooksPaginatedResponse response = new()
            {
                LibraryBooks = [.. libraryBooks],
                TotalCount = result.Item2
            };

            return response;
        }
    }
}
