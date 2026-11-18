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
    internal class AccountCustomerConfigurations : IEntityTypeConfiguration<AccountCustomer>
    {
        public void Configure(EntityTypeBuilder<AccountCustomer> builder)
        {
            builder.HasKey(AC => new { AC.AccountNumber, AC.CustomerId });

            builder.HasOne(AC => AC.Account)
                .WithMany(A => A.AccountCustomers)
                .HasForeignKey(AC => AC.AccountNumber)
                .IsRequired(true);

            builder.HasOne(AC => AC.Customer)
                .WithMany(A => A.AccountCustomers)
                .HasForeignKey(AC => AC.CustomerId)
                .IsRequired(true);

            builder.Property(AC => AC.StartDate)
                .IsRequired(true);
            builder.ToTable(T => T.HasCheckConstraint
                (
                    "CK_AccountCustomers_StartDate",
                    " StartDate <= cast(GetDate() as date) "
                ));

            builder.Property(AC => AC.OwnershipType)
                .IsRequired(true);

            builder.Property(AC => AC.AccountStatus)
                .IsRequired(true);


        }
    }
}
