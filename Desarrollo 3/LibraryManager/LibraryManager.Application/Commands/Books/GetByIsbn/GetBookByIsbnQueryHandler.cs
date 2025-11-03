using Dapper;
using LibraryManager.Application.Abstractions.Data;
using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Books;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Books.GetByIsbn
{
    internal sealed class GetBookByIsbnQueryHandler : IQueryHandler<GetBookByIsbnQuery, GetBookByIsbnResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetBookByIsbnQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<GetBookByIsbnResponse>> Handle(GetBookByIsbnQuery request, CancellationToken cancellationToken)
        {
            using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    id AS Id,
                    isbn AS ISBN,
                    title AS Title,
                    author AS Author,
                    publication_year AS PublicationYear,
                    created_at AS CreatedAt
                FROM book
                WHERE isbn = @Isbn
                """;

            GetBookByIsbnResponse? book = await connection.QueryFirstOrDefaultAsync<GetBookByIsbnResponse>(sql, new { request.Isbn });

            if (book is null)
                return Result.Failure<GetBookByIsbnResponse>(BookErrors.NotFound);

            return book;
        }
    }
}
