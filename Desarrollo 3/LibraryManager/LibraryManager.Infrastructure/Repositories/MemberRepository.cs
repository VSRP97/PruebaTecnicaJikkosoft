using LibraryManager.Domain.Entities.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Repositories
{
    internal sealed class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(LibraryManagerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
