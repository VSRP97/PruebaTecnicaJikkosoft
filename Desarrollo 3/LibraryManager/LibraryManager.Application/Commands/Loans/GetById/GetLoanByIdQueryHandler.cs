using Dapper;
using LibraryManager.Application.Abstractions.Data;
using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Loans;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Loans.GetById
{
    internal sealed class GetLoanByIdQueryHandler : IQueryHandler<GetLoanByIdQuery, GetLoanByIdResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetLoanByIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<GetLoanByIdResponse>> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
        {
            using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    id AS Id,
                    library_book_id AS LibraryBookId,
                    member_id AS MemberId,
                    loan_date AS LoanDate,
                    expected_return_date AS ExpectedReturnDate,
                    return_date AS ReturnDate,
                    status AS Status,
                    created_at AS CreatedAt,
                    loaned_amount AS LoanedAmount
                FROM loan
                WHERE id = @Id
                """;

            GetLoanByIdResponse? loan = await connection.QueryFirstOrDefaultAsync<GetLoanByIdResponse>(sql, new { request.Id });

            if (loan is null)
                return Result.Failure<GetLoanByIdResponse>(LoanErrors.NotFound);

            if (!Enum.IsDefined(typeof(LoanStatus), loan.Status))
                loan.Status = LoanStatus.Unknown.ToString();

            loan.Status = Enum.Parse<LoanStatus>(loan.Status).ToString();

            return Result.Success(loan);
        }
    }
}
