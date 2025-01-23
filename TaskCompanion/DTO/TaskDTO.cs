using ToDoManager.Enum;

namespace ToDoManager.DTO;

public class TaskDTO
{
    public string TaskName { get; set; }
    
    public string TaskDescription { get; set; }

    public TasksStatus TasksStatus { get; set; } = TasksStatus.Aberto;
}