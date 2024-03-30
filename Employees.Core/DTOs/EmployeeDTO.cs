using Employees.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string Identity { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateStart { get; set; }
        public Gender gender { get; set; }
        public List<EmpRoleDTO> Roles { get; set; }
        public bool Status { get; set; }
    }
}
