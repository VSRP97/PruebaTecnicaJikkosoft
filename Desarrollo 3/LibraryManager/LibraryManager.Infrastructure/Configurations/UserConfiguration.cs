using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Infrastructure.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(user => user.Id);

            builder.OwnsOne(user => user.FullName, fullName =>
            {
                fullName.Property(name => name.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(50)
                    .IsRequired();
                fullName.Property(name => name.SecondName)
                    .HasColumnName("second_name")
                    .HasMaxLength(50)
                    .IsRequired(false);
                fullName.Property(name => name.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(50)
                    .IsRequired();
                fullName.Property(name => name.SecondLastName)
                    .HasColumnName("second_last_name")
                    .HasMaxLength(50)
                    .IsRequired(false);
            });

            builder.Property(user => user.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(user => user.Email)
                .IsUnique();
        }
    }
}
