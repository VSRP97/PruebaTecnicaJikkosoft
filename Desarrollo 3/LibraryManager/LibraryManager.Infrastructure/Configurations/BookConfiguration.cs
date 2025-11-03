using LibraryManager.Domain.Entities.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Configurations
{
    internal sealed class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("book");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.ISBN)
                .HasColumnName("isbn")
                .HasMaxLength(13)
                .IsRequired();

            builder.HasIndex(b => b.ISBN)
                .IsUnique();

            builder.Property(b => b.Title)
                .HasColumnName("title")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(b => b.Author)
                .HasColumnName("author")
                .HasMaxLength(150)
                .IsRequired();            

            builder.Property(b => b.PublicationYear)
                .HasColumnName("publication_year")
                .IsRequired();

            builder.Property(b => b.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
        }
    }
}
