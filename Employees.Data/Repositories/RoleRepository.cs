using Employees.Core.Models;
using Employees.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public Task<Role> AddRole(string name)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRole(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetRole(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetRoles()
        {
            throw new NotImplementedException();
        }

        public Task<Role> UpdateRole(int id, string name)
        {
            throw new NotImplementedException();
        }
    }
}
