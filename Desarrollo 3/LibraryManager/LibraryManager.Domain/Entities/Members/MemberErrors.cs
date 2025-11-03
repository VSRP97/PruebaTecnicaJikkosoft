using LibraryManager.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities.Members
{
    public static class MemberErrors
    {
        public static readonly Error NotFound = new(
            "Member.NotFound",
            "The member with the specified identifier was not found.");
    }
}
