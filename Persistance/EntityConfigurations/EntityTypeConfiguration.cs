using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityConfigurations
{
    public abstract class EntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseModel
    {
        protected abstract string Table { get; }
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(this.Table).HasKey(x => x.Id);
        }
    }
}
