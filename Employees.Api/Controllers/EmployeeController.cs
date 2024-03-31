using AutoMapper;
using Employees.Core.DTOs;
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
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> Get([FromQuery] bool? status)
        {
            var list = _employeeService.GetEmployeesAsync().Result
                .Where(e => status is null || status == e.Status);
            var listDTO = _mapper.Map<IEnumerable<EmployeeDTO>>(list);
            return Ok(listDTO);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> Get(int id)
        {
            var emp = await _employeeService.GetEmployeeByIdAsync(id);
            if (emp is null)
                return NotFound();
            var empDTO = _mapper.Map<EmployeeDTO>(emp);
            return Ok(empDTO);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> Post([FromBody] EmployeePostModel employee)
        {
            var emp = _employeeService.GetEmployeesAsync().Result
                .FirstOrDefault(e => e.Identity == employee.Identity);
            if (emp is not null)
                return Conflict();
            var empToAdd = _mapper.Map<Employee>(employee);
            var added = await _employeeService.AddEmployeeAsync(empToAdd);
            return Ok(_mapper.Map<EmployeeDTO>(added));
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDTO>> Put(int id, [FromBody] EmployeePostModel employee)
        {
            var emp = await _employeeService.GetEmployeeByIdAsync(id);
            if (emp is null)
                return NotFound();
            var empToAdd = _mapper.Map<Employee>(employee);
            var update = await _employeeService.UpdateEmployeeAsync(id, empToAdd);
            return Ok(_mapper.Map<EmployeeDTO>(update));
        }
        // PUT api/<EmployeeController>/5
        [HttpPut("delete/{id}")]
        public async Task<ActionResult<EmployeeDTO>> Put(int id)
        {
            var emp = await _employeeService.GetEmployeeByIdAsync(id);
            if (emp is null)
                return NotFound();
            var update = await _employeeService.ChangeStatusAsync(id);
            return Ok(_mapper.Map<EmployeeDTO>(update));
        }
        [HttpGet("{id}/role")]
        public async Task<ActionResult<IEnumerable<EmpRoleDTO>>> GetRoles(int id)
        {
            var emp = await _employeeService.GetEmployeeByIdAsync(id);
            if (emp is null)
                return NotFound();
            var roles = await _employeeService.GetRolesAsync(id);
            var rolesDTO = _mapper.Map<IEnumerable<EmpRoleDTO>>(roles);
            return Ok(rolesDTO);
        }
        [HttpGet("role/{id}")]
        public async Task<ActionResult<EmpRoleDTO>> GetRole(int id)
        {
            var role = await _employeeService.GetRoleByIdAsync(id);
            if (role is null)
                return NotFound();
            var roleDTO = _mapper.Map<EmpRoleDTO>(role);
            return Ok(roleDTO);
        }
        [HttpPost("role")]
        public async Task<ActionResult<EmpRoleDTO>> PostRole(EmpRolePostModel roleToAdd)
        {
            var emp = await _employeeService.GetEmployeeByIdAsync(roleToAdd.EmployeeId);
            if (emp is null)
                return NotFound("Employee Id is invalid");
            var roles = await _employeeService.GetRolesAsync(emp.Id);
            if (roles.Any(r => r.Id == roleToAdd.RoleId))
                return Conflict();
            var role = _mapper.Map<EmpRole>(roleToAdd);
            var added = await _employeeService.AddRoleAsync(role);
            var roleDTO = _mapper.Map<EmpRoleDTO>(added);
            return Ok(roleDTO);
        }
        [HttpPut("role/{id}")]
        public async Task<ActionResult<EmpRoleDTO>> PutRole(int id, EmpRolePostModel roleToUpdate)
        {
            var role = await _employeeService.GetRoleByIdAsync(id);
            if (role is null)
                return NotFound();
            var emp = await _employeeService.GetEmployeeByIdAsync(roleToUpdate.EmployeeId);
            if (emp is null)
                return NotFound("Employee Id is invalid");
            _mapper.Map(roleToUpdate, role);
            var update = await _employeeService.UpdateRoleAsync(id, role);
            var roleDTO = _mapper.Map<EmpRoleDTO>(update);
            return Ok(roleDTO);
        }
        [HttpDelete("role/{id}")]
        public async Task<ActionResult> DeleteRole(int id)
        {
            var role = await _employeeService.GetRoleByIdAsync(id);
            if (role is null) return NotFound();
            await _employeeService.DeleteRoleAsync(id);
            return Ok();
        }

    }
}
