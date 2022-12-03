using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Persistance.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class RepositoryContext : DbContext {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) {
        } 
        public DbSet<Company> Companies { get; set; } 
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EmployeeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyEntityConfiguration());

        }

    }
}
