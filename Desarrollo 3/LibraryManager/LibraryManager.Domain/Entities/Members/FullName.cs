using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities.Members
{
    public sealed record FullName(string FirstName, string? SecondName, string LastName, string? SecondLastName)
    {
        public static implicit operator string(FullName fullName) => fullName.ToString();

        public override string ToString()
        {
            string secondName = SecondName is not null ? $"{SecondName} " : string.Empty;
            string secondLastName = SecondLastName is not null ? $"{SecondLastName}" : string.Empty;
            return $"{FirstName} {secondName}{LastName} {secondLastName}";
        }
    }
}
