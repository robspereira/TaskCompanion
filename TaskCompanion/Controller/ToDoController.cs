using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoManager.Model;
using ToDoManager.Service;

namespace ToDoManager.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly TasksService _service;

        public ToDoController(TasksService service)
        {
            _service = service;
        }
        
        [HttpGet]
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
        [Route("registerTask")]
        public async Task<ActionResult> AddToDo(Tasks newItem)
        {
            if(newItem is null)
                return BadRequest();
            
            var item = await _service.AddTaskAsync(newItem);
            return CreatedAtAction(nameof(GetToDoById), new {id = newItem.TaskId}, newItem);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateToDo(int id, Tasks tasks)
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