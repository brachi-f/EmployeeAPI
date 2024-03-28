using Employees.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Data
{
    public class DataContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}
