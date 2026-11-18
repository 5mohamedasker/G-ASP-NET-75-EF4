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
    internal class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(C => C.Id);
            builder.Property(C => C.Id)
                .IsRequired(true)
                .UseIdentityColumn(10, 10);

            builder.Property(C => C.FullName)
                .HasColumnType("nvarchar(200)")
                .IsRequired(true);

            builder.Property(C => C.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.ToTable(T => T.HasCheckConstraint
                (
                    "CK_Customer_Email",
                    "Email like '%@%.%' "
                ));

            builder.Property(C => C.PhoneNumber)
                .HasColumnType("varchar(50)")
                .IsRequired(true);

            builder.Property(C => C.Address)
                .HasColumnType("nvarchar(200)")
                .IsRequired(true);

            builder.Property(C => C.DateOfBirth)
                .IsRequired(true);
            builder.ToTable(T => T.HasCheckConstraint
                (
                    "CK_Customers_DateOfBirth",
                    " DateOfBirth < cast(GetDate() as date) "
                ));
            builder.Property(C => C.CustomerType)
                .IsRequired(true);

            builder.Property(C => C.Nationalld)
                .HasColumnType("varchar(50)")
                .IsRequired(true);

        }
    }
}
