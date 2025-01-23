using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using ToDoManager.DTO;
using ToDoManager.Model;

namespace ToDoManager.Service;

public class TasksService(AppDbContext _context, IHttpContextAccessor httpContextAccessor)
{
    
    public async Task<Tasks> AddTaskAsync(TaskDTO dto)
    {
        var guid = GetUserId();
        if (guid is null)
            return null; 
        
        var user = await _context.Users.FindAsync(guid);
        if (user == null)
            return null;

        var task = new Tasks
        {
            Name = dto.TaskName,
            Description = dto.TaskDescription,
            Status = dto.TasksStatus,
            UserId = guid.Value,
            User = user

        };
        
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        
        return task;
    }
    
    public async Task<Tasks> GetTaskByIdAsync(int id) { 
        var guid = GetUserId();
        
        if (guid is null)
            return null;
        
        return await _context.Tasks
            .FirstOrDefaultAsync(t => t.TaskId == id && t.UserId == guid.Value);
    }

    public async Task<List<Tasks>> GetAllTasks()
    {
        var guid = GetUserId();
        
        if (guid is null)
            return null;
        
        
        return await _context.Tasks.OrderBy(t => t.UserId == guid).ToListAsync();
    }

    public async Task<Tasks> UpdateTaskAsync(int id, TaskDTO task)
    {
        var guid = GetUserId();
        if (guid is null)
            return null;
        
        var targetTask = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskId == id && 
                                                                       t.UserId == guid.Value);
        if (targetTask is null)
        {
            return null;
        }
        
        targetTask.Name = task.TaskName;
        targetTask.Description = task.TaskDescription;
        targetTask.Status = task.TasksStatus;
        await _context.SaveChangesAsync();
        return targetTask;
            
    }

    public async Task<Tasks> DeleteTaskAsync(int id)
    {
        var guid = GetUserId();
        if (guid is null)
            return null;
        
        var targetTask = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskId == id && 
                                                                       t.UserId == guid.Value);
        if (targetTask is null)
            return null;
    
        _context.Tasks.Remove(targetTask);
        await _context.SaveChangesAsync();
        return targetTask;
    }
    
    
    private Guid? GetUserId()
    {
        var userIdClaim = httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (Guid.TryParse(userIdClaim, out var userId))
        {
            return userId;
        }
        return null; 
    }
    
    
}