using Employees.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Repositories
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetRoles();
        Role GetRole(int id);
        Role AddRole(string name);
        void DeleteRole(int id);
        Role UpdateRole(int id, string name);

    }
}
