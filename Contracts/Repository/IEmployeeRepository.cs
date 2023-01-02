using Entities.Models;
using Entities.RequestFeatures;
using Entities.RequestFeatures.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IEmployeeRepository
    {
        Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges);

        Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges);

        Task CreateEmployeeForCompanyAsync(Guid companyId, Employee employee);

        Task DeleteEmployeeAsync(Employee employee);
    }
}
