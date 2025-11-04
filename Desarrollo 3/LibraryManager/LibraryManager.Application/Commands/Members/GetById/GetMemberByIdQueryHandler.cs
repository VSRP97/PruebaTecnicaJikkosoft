using Dapper;
using LibraryManager.Application.Abstractions.Data;
using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Members;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Members.GetById
{
    internal sealed class GetMemberByIdQueryHandler : IQueryHandler<GetMemberByIdQuery, GetMemberByIdResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetMemberByIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<GetMemberByIdResponse>> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
        {
            using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    id AS Id,
                    name AS Name,
                    email AS Email
                FROM member
                WHERE id = @Id
                """;

            GetMemberByIdResponse? member = await connection.QueryFirstOrDefaultAsync<GetMemberByIdResponse>(sql, new { request.Id });

            if (member is null)
                return Result.Failure<GetMemberByIdResponse>(MemberErrors.NotFound);

            return member;
        }
    }
}
