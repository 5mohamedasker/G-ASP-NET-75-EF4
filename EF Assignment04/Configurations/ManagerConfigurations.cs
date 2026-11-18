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
    internal class ManagerConfigurations : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(M => M.Id);
            builder.Property(M => M.Id)
                .IsRequired(true)
                .UseIdentityColumn(10, 10);

            builder.Property(M => M.FullName)
                .HasColumnType("nvarchar(200)")
                .IsRequired(true);

            builder.Property(M => M.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.ToTable(T => T.HasCheckConstraint
                (
                    "CK_Managers_Email",
                    "Email like '%@%.%' "
                ));

            builder.Property(M => M.PhoneNumber)
                .HasColumnType("varchar(50)")
                .IsRequired(true);

            builder.Property(M => M.HireDate)
                .IsRequired(true);
            builder.ToTable(T => T.HasCheckConstraint
                (
                    "CK_Managers_HireDate",
                    " HireDate <= cast(GetDate() as date) "
                ));


            builder.HasData
                (
                    new Manager {Id = 10, FullName = "Mohamed Abdullah Asker", Email = "mohamed@gmail.com", PhoneNumber = "01025091879", HireDate = new DateOnly(2026, 9, 22) },
                    new Manager { Id = 20, FullName = "Ali Ahmed Reda", Email = "ali@gmail.com", PhoneNumber = "01282477388", HireDate = new DateOnly(2026, 10, 5) }
                );
        }
    }
}
