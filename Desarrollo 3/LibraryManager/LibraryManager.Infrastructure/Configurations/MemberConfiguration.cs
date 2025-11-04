using LibraryManager.Domain.Entities.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Configurations
{
    internal sealed class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("member");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.Email)
                .HasColumnName("email")
                .HasMaxLength(150)
                .IsRequired();

            builder
                .HasMany(m => m.Libraries)
                .WithMany(l => l.Members)
                .UsingEntity("library_member");

            builder
                .HasIndex(m => m.Email)
                .IsUnique();
        }
    }
}
