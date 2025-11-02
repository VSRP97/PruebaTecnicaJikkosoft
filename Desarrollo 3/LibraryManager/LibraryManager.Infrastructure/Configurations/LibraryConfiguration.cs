using LibraryManager.Domain.Entities.Libraries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Configurations
{
    internal sealed class LibraryConfiguration : IEntityTypeConfiguration<Library>
    {
        public void Configure(EntityTypeBuilder<Library> builder)
        {
            builder.ToTable("library");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Name)
                .HasColumnName("name")
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
