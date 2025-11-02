using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Books;
using LibraryManager.Domain.Entities.Libraries;
using LibraryManager.Domain.Entities.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities.Members
{
    /// <summary>
    /// Represents a member of a library
    /// </summary>
    public sealed class Member : Entity
    {
        private Member(Guid id, string name, string email) : base(id)
        {
            Name = name;
            Email = email;
        }

        private Member()
        {            
        }

        /// <summary>
        /// Identifier of the library the member belongs to
        /// </summary>
        public Guid LibraryId { get; set; }

        /// <summary>
        /// Name of the member
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Email address of the member
        /// </summary>
        public string Email { get; private set; }


        #region Navigation
        public Library Library { get; set; }
        public ICollection<Loan> Loans { get; private set; } = [];
        #endregion

        /// <summary>
        /// Creates a new instance of the <see cref="Member"/> class with a unique identifier.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <returns>A new <see cref="Member"/> object initialized with the specified full name and email address.</returns>
        public static Member Create(
            string name,
            string email)
        {
            var member = new Member(
                Guid.NewGuid(),
                name,
                email);

            return member;
        }

        /// <summary>
        /// Updates the member's information.
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="email"></param>
        /// <returns>A <see cref="Result"></returns>
        public Result Update(
            string fullName,
            string email)
        {
            Name = fullName;
            Email = email;

            return Result.Success();
        }
    }
}
