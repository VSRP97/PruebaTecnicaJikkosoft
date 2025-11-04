using Dapper;
using LibraryManager.Application.Abstractions.Data;
using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.LibraryBooks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.LibraryBooks.GetById
{
    internal sealed class GetLibraryBookByIdQueryHandler : IQueryHandler<GetLibraryBookByIdQuery, GetLibraryBookByIdResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetLibraryBookByIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<GetLibraryBookByIdResponse>> Handle(GetLibraryBookByIdQuery request, CancellationToken cancellationToken)
        {
            using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    lb.id AS Id,
                    lb.library_id AS LibraryId,
                    lb.book_id AS BookId,
                    lb.total_copies AS TotalCopies,
                    lb.available_copies AS AvailableCopies,
                    l.name AS LibraryName,
                    b.title AS BookTitle
                FROM library_book lb
                JOIN library l ON lb.library_id = l.id
                JOIN book b ON lb.book_id = b.id
                WHERE lb.id = @Id
                """;

            GetLibraryBookByIdResponse? libraryBook = await connection.QueryFirstOrDefaultAsync<GetLibraryBookByIdResponse>(sql, new { request.Id });

            if (libraryBook is null)
                return Result.Failure<GetLibraryBookByIdResponse>(LibraryBookErrors.NotFound);

            return libraryBook;
        }
    }
}
