using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities.Loans
{
    public enum LoanStatus
    {
        Unknown = -1,
        Created,
        Loaned,
        Returned
    }
}
