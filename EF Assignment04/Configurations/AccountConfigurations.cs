using EF_Assignment04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Assignment04.Configurations
{
    internal class AccountConfigurations : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(A => A.AccountNumber);
            builder.Property(A => A.AccountNumber)
                .IsRequired(true)
                .UseIdentityColumn(10000, 10);

            builder.HasOne(A => A.Branch)
                .WithMany(B => B.Accounts)
                .HasForeignKey(A => A.BranchCode)
                .IsRequired(true);


            builder.Property(A => A.CurrentBalance)
                .HasColumnType("decimal(16,2)")
                .IsRequired(true);

            builder.Property(A => A.AccountType)
                .IsRequired(true);

            builder.Property(A => A.OpeningDate)
                .IsRequired(true);
            builder.ToTable(T => T.HasCheckConstraint
                (
                    "CK_Accounts_Openingdate",
                    " OpeningDate <= GetDate() "
                ));

        }
    }
}
