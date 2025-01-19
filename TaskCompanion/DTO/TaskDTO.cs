using TaskStatus = ToDoManager.Enum.TaskStatus;

namespace ToDoManager.DTO;

public class TaskDTO
{
    public string TaskName { get; set; }
    
    public string TaskDescription { get; set; }

    public TaskStatus TaskStatus { get; set; } = TaskStatus.Aberto;
}