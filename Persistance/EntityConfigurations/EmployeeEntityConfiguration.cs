using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityConfigurations
{
    public class EmployeeEntityConfiguration : EntityTypeConfiguration<Employee>
    {
        public const string TableName = "Employee";
        private const string CompanyIdColumn = "CompanyId";

        protected override string Table => TableName;

        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Position).IsRequired().HasMaxLength(20);

            builder.Property(x => x.Age).IsRequired();

            builder.HasOne(x => x.Company)
                   .WithMany()
                   .HasForeignKey(x=> x.CompanyId)
                   .HasConstraintName(
                        ForeignKeyNameBuilder.Build(
                            this.Table,
                            EmployeeEntityConfiguration.TableName,
                            CompanyIdColumn))
                    .OnDelete(DeleteBehavior.Restrict);
                        }
    }
}
