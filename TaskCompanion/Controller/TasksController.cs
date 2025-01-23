using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoManager.DTO;
using ToDoManager.Model;
using ToDoManager.Service;

namespace ToDoManager.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TasksService _service;

        public TasksController(TasksService service)
        {
            _service = service;
        }
        
        [HttpGet]
        [Route("listAll")]
        public async Task<ActionResult<List<Task>>> GetTasks()
        {
            var tasks = await _service.GetAllTasks();
            return Ok(tasks);
        }
        
        
        [HttpGet]
        [Route("findTaskById/{id}")]
        public async Task<ActionResult> GetToDoById(int id)
        {
            var item = await _service.GetTaskByIdAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            
            return Ok(item);
        }

        [HttpPost]
        [Authorize]
        [Route("registerTask")]
        public async Task<ActionResult> AddTask([FromBody] TaskDTO newItem)
        {
            if (newItem is null)
                return BadRequest();
            
            var task = await _service.AddTaskAsync(newItem);

            if (task == null)
                return Unauthorized();  
            
            return CreatedAtAction(nameof(GetToDoById), new { id = task.TaskId }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateTask(int id, TaskDTO tasks)
        {
            var item = await _service.UpdateTaskAsync(id, tasks);
            
            if (item == null)
            {
                return NotFound();
            }
        
            return NoContent();
        }
        
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _service.DeleteTaskAsync(id);
            if (item is null)
            {
                return NotFound();
            }
        
            return NoContent();
        }

    }
    
}