using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Books;
using LibraryManager.Domain.Entities.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities.Libraries
{
    public sealed class Library : Entity
    {

        public Library()
        {
        }

        public string Name { get; set; }

        #region Navigation
        public ICollection<Book> Books { get; private set; } = [];
        public ICollection<Member> Members { get; private set; } = [];
        #endregion
    }
}
