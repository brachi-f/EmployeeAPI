using Employees.Core.Models;
using Employees.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employees.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        // GET: api/<RoleController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> Get()
        {
            var list = await _roleService.GetRoles();
            return Ok(list);
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> Get(int id)
        {
            var role = await _roleService.GetRole(id);
            if (role is null)
                return NotFound();
            return Ok(role);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult<Role>> Post([FromBody] string name)
        {
            var role = await _roleService.AddRole(name);
            return Ok(role);
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Role>> Put(int id, [FromBody] string name)
        {
            var role = await _roleService.GetRole(id);
            if (role is null)
                return NotFound();
            role = await _roleService.UpdateRole(id, name);
            return Ok(role);
            
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var role = await _roleService.GetRole(id);
            if (role is null)
                return NotFound();
            await _roleService.DeleteRole(id);
            return Ok();
        }
    }
}
