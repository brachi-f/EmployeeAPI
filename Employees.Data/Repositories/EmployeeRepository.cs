using AutoMapper;
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
        private readonly IMapper _mapper;
        public EmployeeRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Employee> AddEmployeeAsync(Employee emp)
        {
            await _dataContext.Employees.AddAsync(emp);
            await _dataContext.SaveChangesAsync();
            return emp;
        }

        public async Task<EmpRole> AddRoleAsync(EmpRole role)
        {
            await _dataContext.EmpRoles.AddAsync(role);
            await _dataContext.SaveChangesAsync();
            return role;
        }

        public async Task<Employee> ChangeStatusAsync(int id)
        {
            var emp = await GetEmployeeByIdAsync(id);
            emp.Status = false;
            await _dataContext.SaveChangesAsync();
            return emp;
        }

        public async Task DeleteRoleAsync(int id)
        {
            var role = await _dataContext.EmpRoles.FindAsync(id);
            _dataContext.EmpRoles.Remove(role);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _dataContext.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _dataContext.Employees.Include(e => e.Roles).ThenInclude(r => r.Role).ToListAsync();
        }

        public async Task<EmpRole> GetRoleByIdAsync(int id)
        {
            return await _dataContext.EmpRoles.Include(r => r.Employee).Include(r => r.Role).FirstAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<EmpRole>> GetRolesAsync(int id)
        {
            return await _dataContext.EmpRoles.Include(r => r.Role).Where(r => r.EmployeeId == id).ToListAsync();
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee emp)
        {
            var employee = await _dataContext.Employees.FindAsync(id);
            _mapper.Map(emp, employee);
            _dataContext.Employees.Update(employee);
            await _dataContext.SaveChangesAsync();
            return employee;
        }

        public async Task<EmpRole> UpdateRoleAsync(int id, EmpRole role)
        {
            var oldRole = await _dataContext.EmpRoles.FindAsync(id);
            _mapper.Map(role, oldRole);
            _dataContext.EmpRoles.Update(oldRole);
            await _dataContext.SaveChangesAsync();
            return oldRole;
        }
    }
}
