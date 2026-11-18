using Microsoft.EntityFrameworkCore;
using EF_Assignment04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Assignment04.Configurations
{

    internal class TransactionConfigurations : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(T => T.TransactionNumber);
            builder.Property(T => T.TransactionNumber)
                .IsRequired(true)
                .UseIdentityColumn(1, 1);

            builder.HasOne(T => T.Account)
                .WithMany(A => A.Transactions)
                .HasForeignKey(T => T.AccountNumber)
                .IsRequired(true);

            builder.Property(T => T.TransactionDate)
                .IsRequired(true);
            builder.ToTable(T => T.HasCheckConstraint
                (
                    "CK_Transactions_TransactionDate",
                    " TransactionDate <= cast(GetDate() as date) "
                ));
            builder.Property(T => T.Amount)
                .HasColumnType("decimal(16,2)")
                .IsRequired(true);

            builder.Property(T => T.TransactionType)
                .IsRequired(true);

            builder.Property(T => T.Note)
                .HasColumnType("nvarchar(500)")
                .IsRequired(true);
        }
    }
}
