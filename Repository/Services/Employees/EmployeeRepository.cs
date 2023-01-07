using Contracts.Repository;
using Entities.Models;
using Entities.RequestFeatures;
using Entities.RequestFeatures.Common;
using Entities.RequestFeatures.Employee;
using Microsoft.EntityFrameworkCore;
using Persistance.Repositories;
using Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.Employees
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges)
        {
           var employees = await FindByCondition(e =>  e.CompanyId.Equals(companyId), trackChanges)
            .FilterEmployees(employeeParameters.MinAge, employeeParameters.MaxAge)
            .Search(employeeParameters.SearchTerm)
            .Sort(employeeParameters.OrderBy)
            .Skip((employeeParameters.PageNumber - 1) * employeeParameters.PageSize)
            .Take(employeeParameters.PageSize)
            .ToListAsync();

            var count = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges).CountAsync();

            return new PagedList<Employee>(employees, employeeParameters.PageNumber, employeeParameters.PageSize, count);
        }             

        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges) => await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public async Task CreateEmployeeForCompanyAsync(Guid companyId, Employee employee) { 
            employee.CompanyId = companyId; 
            Create(employee); 
        }

        public async Task DeleteEmployeeAsync(Employee employee) { Delete(employee); }
    }
}
