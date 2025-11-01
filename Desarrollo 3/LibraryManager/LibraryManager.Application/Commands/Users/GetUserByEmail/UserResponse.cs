using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Users.GetUserByEmail
{
    public class UserResponse
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string? SecondName { get; init; }
        public string LastName { get; init; }
        public string? SecondLastName { get; init; }
        public string Email { get; init; }
    }
}
