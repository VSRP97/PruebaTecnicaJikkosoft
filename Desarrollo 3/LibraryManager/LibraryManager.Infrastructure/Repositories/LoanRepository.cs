using LibraryManager.Domain.Entities.Loans;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Repositories
{
    internal sealed class LoanRepository(LibraryManagerDbContext dbContext) : Repository<Loan>(dbContext), ILoanRepository
    {
        public async Task<(IReadOnlyList<Loan>, int)> GetAllLoansPaginated(
            int skip,
            int limit,
            string? search,
            LoanStatus? status,
            Guid? bookId,
            Guid? memberId,
            CancellationToken cancellationToken = default)
        {
            var query = DbContext.Set<Loan>().AsQueryable();

            var totalRecords = query.Count();

            if (bookId is not null)
                query = query.Where(loan => loan.LibraryBook.BookId == bookId);

            if (memberId is not null)
                query = query.Where(loan => loan.MemberId == memberId);

            if (!string.IsNullOrEmpty(search))
                query = query.Where(loan => loan.LibraryBook.Book.Title.Contains(search) || loan.Member.Name.Contains(search));

            if (status is not null)
                query = query.Where(loan => loan.Status == status);

            query = query.Skip(skip).Take(limit);

            var loans = await query
                .OrderByDescending(l => l.CreatedAt)
                .Include(l => l.LibraryBook.Book)
                .ToListAsync(cancellationToken);

            return (loans, totalRecords);
        }
    }
}
