using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Users.Events;

namespace LibraryManager.Domain.Entities.Users
{
    public sealed class User : Entity
    {
        public User(Guid id, FullName fullName, string email)
            : base(id)
        {
            FullName = fullName;
            Email = email;
        }
        public User()
        {
        }

        public FullName FullName { get; private set; }
        public string Email { get; private set; }

        public static User Create(FullName fullName, string email)
        {
            var user = new User(Guid.NewGuid(), fullName, email);

            user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

            return user;
        }
    }
}