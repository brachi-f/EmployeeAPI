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
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _dataContext;
        public RoleRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Role> AddRole(string name)
        {
            var r = new Role() { Id = 0, Name = name };
            await _dataContext.Roles.AddAsync(r);
            await _dataContext.SaveChangesAsync();
            return r;
        }

        public async Task DeleteRole(int id)
        {
            var role = await _dataContext.Roles.FindAsync(id);
            _dataContext.Roles.Remove(role);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Role> GetRole(int id)
        {
            var role = await _dataContext.Roles.FindAsync(id);
            return role;
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            var list = await _dataContext.Roles.ToListAsync();
            return list;
        }

        public async Task<Role> UpdateRole(int id, string name)
        {
            var role = await _dataContext.Roles.FindAsync(id);
            role.Name = name;
            _dataContext.Roles.Update(role);
            await _dataContext.SaveChangesAsync();
            return role;
        }
    }
}
