using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Models
{
    public enum Gender { Male = 0, Female = 1 }
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string Identity { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender gender { get; set; }
        public List<EmpRole> Roles { get; set; }
        public bool Status { get; set; }

    }
}
