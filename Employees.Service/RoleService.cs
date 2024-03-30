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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<Role> AddRole(string name)
        {
            return await _roleRepository.AddRole(name);
        }

        public async Task DeleteRole(int id)
        {
            await _roleRepository.DeleteRole(id);
        }

        public async Task<Role> GetRole(int id)
        {
            return await _roleRepository.GetRole(id);
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            return await _roleRepository.GetRoles();
        }

        public async Task<Role> UpdateRole(int id, string name)
        {
            return await _roleRepository.UpdateRole(id, name);
        }
    }
}
