using Employees.Core.Models;

namespace Employees.Core.Models
{
    public class EmpRolePostModel
    {
        public int EmployeeId { get; set; }//???
        public int RoleId { get; set; }
        public DateTime DateStart { get; set; }
        public bool Management { get; set; }
    }
}
