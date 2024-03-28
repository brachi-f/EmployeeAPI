using Employees.Core.Models;
using Employees.Core.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employees.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get([FromQuery] bool? status)
        {
            var list = _employeeService.GetEmployeesAsync().Result
                .Where(e => status is null || status == e.Status);
            return Ok(list);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            Employee emp;
            try
            {
                emp = await _employeeService.GetEmployeeByIdAsync(id);
            }
            catch
            {
                return NotFound();
            }
            return Ok(emp);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult<Employee>> Post([FromBody] Employee employee)
        {
            var emp = _employeeService.GetEmployeesAsync().Result
                .FirstOrDefault(e => e.Identity == employee.Identity);
            if (emp is not null)
                return Conflict();
            var added = await _employeeService.AddEmployeeAsync(employee);
            return Ok(added);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Put(int id, [FromBody] Employee employee)
        {
            var emp = await _employeeService.GetEmployeeByIdAsync(id);
            if (emp is null)
                return NotFound();
            var update = await _employeeService.UpdateEmployeeAsync(id, employee);
            return Ok(update);
        }
        // PUT api/<EmployeeController>/5
        [HttpPut("delete/{id}")]
        public async Task<ActionResult<Employee>> Put(int id)
        {
            var emp = await _employeeService.GetEmployeeByIdAsync(id);
            if (emp is null)
                return NotFound();
            var update = await _employeeService.ChangeStatusAsync(id);
            return Ok(update);
        }



    }
}
