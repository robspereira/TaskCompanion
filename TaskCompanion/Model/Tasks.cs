using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ToDoManager.Enum;

namespace ToDoManager.Model;

public class Tasks
{
    [Key]
    public int TaskId { get; set; }
    
    [Column(TypeName = "varchar(30)")]
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public string? Description { get; set; }
    
    [Column(TypeName = "varchar(20)")]
    public TasksStatus Status { get; set; } = TasksStatus.Aberto;
    
    public Guid UserId { get; set; }
    
    [JsonIgnore]
    [ForeignKey("UserId")]
    public User User { get; set; }
    
    public void SetUserId(Guid userId)
    {
        UserId = userId;
    }
    
}