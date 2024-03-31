using Employees.Core.Models;

namespace Employees.Core.Models
{
    public class EmployeePostModel
    {
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string Identity { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender gender { get; set; }
        public bool Status { get; set; }
    }
}
