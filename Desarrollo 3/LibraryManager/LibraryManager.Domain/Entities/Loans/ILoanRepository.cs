using LibraryManager.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities.Loans
{
    public interface ILoanRepository : IRepository<Loan>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="limit"></param>
        /// <param name="search"></param>
        /// <param name="status"></param>
        /// <param name="bookId"></param>
        /// <param name="memberId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Tuple where the first value is the list of loans and the second is the total in the set</returns>
        public Task<(IReadOnlyList<Loan>, int)> GetAllLoansPaginated(
            int skip,
            int limit,
            string? search,
            LoanStatus? status,
            Guid? bookId,
            Guid? memberId,
            CancellationToken cancellationToken = default);

        public Task<Loan?> GetById(Guid id, CancellationToken cancellationToken = default);
    }
}
