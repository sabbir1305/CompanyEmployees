using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityConfigurations
{
    public class CompanyEntityConfiguration : EntityTypeConfiguration<Company>
    {
        public const string TableName = "Company";

        protected override string Table => TableName;

        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            base.Configure(builder);
            builder.HasKey(x=> x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(60);

            builder.Property(x => x.Address).IsRequired(false).HasMaxLength(60);
        }
    }
}
