using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Books.GetAllPaginated
{
    internal class GetAllBooksPaginatedQueryHandler
        : IQueryHandler<GetAllBooksPaginatedQuery, GetAllBooksPaginatedResponse>
    {
        private readonly IBookRepository _bookRepo;

        public GetAllBooksPaginatedQueryHandler(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public async Task<Result<GetAllBooksPaginatedResponse>> Handle(GetAllBooksPaginatedQuery request, CancellationToken cancellationToken)
        {
            var result = await _bookRepo.GetAllBooksPaginated(
                request.Skip,
                request.Limit,
                request.Search);

            var books = result.Item1.Select(b =>
            {
                return new GetBookResponse()
                {
                    Id = b.Id,
                    ISBN = b.ISBN,
                    Author = b.Author,
                    Title = b.Title,
                    PublicationYear = b.PublicationYear,
                    CreatedAt = b.CreatedAt
                };
            });

            GetAllBooksPaginatedResponse response = new()
            {
                Books = [.. books],
                TotalCount = result.Item2
            };

            return response;
        }
    }
}
