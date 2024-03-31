using Employees.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> AddEmployeeAsync(Employee emp);
        Task<Employee> UpdateEmployeeAsync(int id, Employee emp);
        Task<Employee> ChangeStatusAsync(int id);
        Task<IEnumerable<EmpRole>> GetRolesAsync(int id);
        Task<EmpRole> GetRoleByIdAsync(int id);
        Task<EmpRole> AddRoleAsync(EmpRole role);
        Task<EmpRole> UpdateRoleAsync(int id, EmpRole role);
        Task DeleteRoleAsync(int id);
    }
}
