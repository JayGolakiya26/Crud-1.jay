using Crud_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly EmployeeContext _employeeContext;
        public TaskController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taskes>>> GetTasks()
        {
            if (_employeeContext.Tasks == null)
            {
                return NotFound();
            }
            return await _employeeContext.Tasks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Taskes>> GetTaskes(int id)
        {
            var task = await _employeeContext.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }


        [HttpPost]

        public async Task<ActionResult<Taskes>> PostEmployee(Taskes task)
        {
            _employeeContext.Tasks.Add(task);
            await _employeeContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaskes), task);
        }


        [HttpPut]

        public async Task<ActionResult> PutEmployee(int id, Taskes task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            _employeeContext.Entry(task).State = EntityState.Modified;
            try
            {
                await _employeeContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok();
        }

        [HttpDelete]

        public async Task<ActionResult> DeleteTaskes(int id)
        {
            if (_employeeContext.Tasks == null)
            {
                return NotFound();
            }
            var employee = await _employeeContext.Tasks.FindAsync(id)
;
            if (employee == null)
            {
                return NotFound();
            }
            _employeeContext.Tasks.Remove(employee);
            await _employeeContext.SaveChangesAsync();

            return Ok();
        }
    }
}
