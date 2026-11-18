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
    internal class BranchConfigurations : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(B => B.Code);
            builder.Property(B => B.Code)
                .IsRequired(true)
                .UseIdentityColumn(1000,10);

            builder.HasOne(B => B.Manager)
                .WithOne(M => M.Branch)
                .HasForeignKey<Branch>(B => B.ManagerId)
                .IsRequired(true);

            builder.Property(B => B.Name)
                .HasColumnType("nvarchar(100)")
                .IsRequired(true);

            builder.Property(B => B.Address)
                .HasColumnType("nvarchar(200)")
                .IsRequired(true);

            builder.Property(B => B.PhoneNumber)
                .HasColumnType("varchar(50)")
                .IsRequired(true);

            builder.HasData
                ( 
                    new Branch { Code = 1010, Name = "Naser City", Address = "Abas",  PhoneNumber = "0989999", ManagerId = 10 },
                    new Branch { Code = 1020, Name = "Geza",       Address = "Harem", PhoneNumber = "0987777", ManagerId = 20 }
                );
        }
    }
}
