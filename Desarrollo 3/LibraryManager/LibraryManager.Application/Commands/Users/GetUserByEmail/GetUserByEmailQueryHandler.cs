using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using LibraryManager.Application.Abstractions.Data;
using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Users;

namespace LibraryManager.Application.Commands.Users.GetUserByEmail
{
    internal sealed class GetUserByEmailQueryHandler : IQueryHandler<GetUserByEmailQuery, UserResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetUserByEmailQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<UserResponse>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    id AS Id,
                    first_name AS FirstName,
                    second_name AS SecondName,
                    last_name AS LastName,
                    second_last_name AS SecondLastName,
                    email AS Email
                FROM users
                WHERE email = @Email
                """;

            UserResponse? user = await connection.QueryFirstOrDefaultAsync<UserResponse>(sql, new { request.Email });

            if (user == null)
            {
                return Result.Failure<UserResponse>(UserErrors.NotFound);
            }

            return user;
        }
    }
}
