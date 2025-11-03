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

namespace LibraryManager.Application.Commands.Books.GetById
{
    internal sealed class GetBookByIdQueryHandler : IQueryHandler<GetBookByIdQuery, GetBookByIdResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetBookByIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<GetBookByIdResponse>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
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
                WHERE id = @Id
                """;

            GetBookByIdResponse? book = await connection.QueryFirstOrDefaultAsync<GetBookByIdResponse>(sql, new { request.Id });

            if (book is null)
                return Result.Failure<GetBookByIdResponse>(BookErrors.NotFound);

            return book;
        }
    }
}
