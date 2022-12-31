using Contracts.Repository;
using Persistance.Repositories;
using Repository.Services.Companies;
using Repository.Services.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext repositoryContext;
        private ICompanyRepository companyRepository;
        private IEmployeeRepository employeeRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public ICompanyRepository CompanyRepository
        {
            get {
                if (companyRepository == null)
                    companyRepository = new CompanyRepository(repositoryContext);
                return companyRepository; 
            }
        }

        public IEmployeeRepository EmployeeRepository {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepository(repositoryContext);
                return employeeRepository;
            }
        }

        public async Task SaveAsync() => await repositoryContext.SaveChangesAsync();
    }
}
