using AutoMapper;
using Employees.Api.Models;
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




    }
}
