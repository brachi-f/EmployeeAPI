using Employees.Core.Models;
using Employees.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _dataContext;
        public EmployeeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Employee> AddEmployeeAsync(Employee emp)
        {
            await _dataContext.Employees.AddAsync(emp);
            await _dataContext.SaveChangesAsync();
            return emp;
        }

        public async Task<Employee> ChangeStatusAsync(int id)
        {
            var emp = await GetEmployeeByIdAsync(id);
            emp.Status = false;
            await _dataContext.SaveChangesAsync();
            return emp;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return GetEmployeesAsync().Result.First(e => e.Id == id);
                    }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _dataContext.Employees.Include(e => e.Roles).ThenInclude(r=>r.Role).ToListAsync();
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee emp)
        {
            var employee = await GetEmployeeByIdAsync(id);
            employee.FirstName = emp.FirstName;
            //TODO auto mapper
            await _dataContext.SaveChangesAsync();
            return employee;
        }
    }
}
