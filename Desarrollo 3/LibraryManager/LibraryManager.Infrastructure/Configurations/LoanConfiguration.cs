using LibraryManager.Domain.Entities.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Configurations
{
    internal sealed class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("loan");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.LoanDate)
                .HasColumnName("loan_date")
                .IsRequired();

            builder.Property(l => l.ReturnDate)
                .HasColumnName("return_date")
                .IsRequired(false);

            builder.Property(l => l.ExpectedReturnDate)
                .HasColumnName("expected_return_date")
                .IsRequired();

            builder.Property(l => l.Status)
                .HasColumnName("status")
                .HasConversion(type => (int)type, value => (LoanStatus)value)
                .IsRequired();

            builder.Property(l => l.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(l => l.LoanedAmount)
                .HasColumnName("loaned_amount")
                .IsRequired();

            builder
                .HasOne(l => l.LibraryBook)
                .WithMany(lb => lb.Loans)
                .HasForeignKey(l => l.LibraryBookId)
                .IsRequired();

            builder
                .HasOne(l => l.Member)
                .WithMany(m => m.Loans)
                .HasForeignKey(l => l.MemberId)
                .IsRequired();
        }
    }
}
