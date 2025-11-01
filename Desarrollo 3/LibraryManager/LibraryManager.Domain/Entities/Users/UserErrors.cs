using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Domain.Abstractions;

namespace LibraryManager.Domain.Entities.Users
{
    public static class UserErrors
    {
        public static readonly Error NotFound = new(
        "User.Found",
        "The user with the specified identifier was not found");
    }
}
