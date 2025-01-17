using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public string Status { get; set; } = "Aberto";
    
}