using LibraryManager.Domain.Entities.LibraryBooks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Configurations
{
    internal sealed class LibraryBookConfiguration : IEntityTypeConfiguration<LibraryBook>
    {
        public void Configure(EntityTypeBuilder<LibraryBook> builder)
        {
            builder.ToTable("library_book");

            builder.HasKey(lb => lb.Id);

            builder.Property(lb => lb.TotalCopies)
                .HasColumnName("total_copies")
                .IsRequired();

            builder.Property(lb => lb.AvailableCopies)
                .HasColumnName("available_copies")
                .IsRequired();

            builder.HasOne(lb => lb.Library)
                .WithMany(l => l.LibraryBooks)
                .HasForeignKey(lb => lb.LibraryId)
                .IsRequired();

            builder.HasOne(lb => lb.Book)
                .WithMany(b => b.LibraryBooks)
                .HasForeignKey(lb => lb.BookId)
                .IsRequired();
        }
    }
}
