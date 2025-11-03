using Dapper;
using LibraryManager.Application.Abstractions.Data;
using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Libraries.GetById
{
    internal sealed class GetLibraryByIdQueryHandler : IQueryHandler<GetLibraryByIdQuery, LibraryResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetLibraryByIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<LibraryResponse>> Handle(GetLibraryByIdQuery request, CancellationToken cancellationToken)
        {
            using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    id AS Id,
                    name AS Name
                FROM library
                WHERE id = @Id
                """;

            LibraryResponse? library = await connection.QueryFirstOrDefaultAsync<LibraryResponse>(sql, new { request.Id });

            if (library is null)
                return Result.Failure<LibraryResponse>(LibraryErrors.NotFound);

            return library;
        }
    }
}
