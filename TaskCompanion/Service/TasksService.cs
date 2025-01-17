using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ToDoManager.Model;

namespace ToDoManager.Service;

public class TasksService
{
    private readonly AppDbContext _context;

    public TasksService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Tasks> AddTaskAsync(Tasks task) {  
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }
    
    public async Task<Tasks> GetTaskByIdAsync(int id) {  // Alterei para TaskItem
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<List<Tasks>> GetAllTasks()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<Tasks> UpdateTaskAsync(int id, Tasks task)
    {
        var targetTask = await _context.Tasks.FindAsync(id);
        
        if (targetTask is null)
        {
            return null;
        }
        
        targetTask.Name = task.Name;
        targetTask.Description = task.Description;
        targetTask.Status = task.Status;
        await _context.SaveChangesAsync();
        return targetTask;
            
    }

    public async Task<Tasks> DeleteTaskAsync(int id)
    {
        var targetTask = await _context.Tasks.FindAsync(id);

        if (targetTask is null)
            return null;
    
        _context.Tasks.Remove(targetTask);
        await _context.SaveChangesAsync();
        return targetTask;
    }
    
}