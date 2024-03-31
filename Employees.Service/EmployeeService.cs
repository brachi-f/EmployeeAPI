using Employees.Core.Models;
using Employees.Core.Repositories;
using Employees.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employee> AddEmployeeAsync(Employee emp)
        {
            return await _employeeRepository.AddEmployeeAsync(emp);
        }

        public async Task<EmpRole> AddRoleAsync(EmpRole role)
        {
            return await _employeeRepository.AddRoleAsync(role);
        }

        public async Task<Employee> ChangeStatusAsync(int id)
        {
            return await _employeeRepository.ChangeStatusAsync(id);
        }

        public async Task DeleteRoleAsync(int id)
        {
            await _employeeRepository.DeleteRoleAsync(id);
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _employeeRepository.GetEmployeesAsync();
        }

        public async Task<EmpRole> GetRoleByIdAsync(int id)
        {
            return await _employeeRepository.GetRoleByIdAsync(id);
        }

        public async Task<IEnumerable<EmpRole>> GetRolesAsync(int id)
        {
            return await _employeeRepository.GetRolesAsync(id);
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee emp)
        {
            return await _employeeRepository.UpdateEmployeeAsync(id, emp);
        }

        public async Task<EmpRole> UpdateRoleAsync(int id, EmpRole role)
        {
            return await _employeeRepository.UpdateRoleAsync(id, role);
        }
    }
}
