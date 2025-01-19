using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoManager.Enum;

namespace ToDoManager.Model;

public class User
{
    [Key]
    public Guid UserId { get; set; } = Guid.NewGuid();
    
    [Column(TypeName = "varchar(30)")]
    public string Username { get; set; } = string.Empty;
    
    [Column(TypeName = "varchar(255)")]
    public string PasswordHash { get; set; } = string.Empty;
    
    [Column(TypeName = "varchar(30)")]
    public Roles Role { get; set; } = Roles.User;
    
    [Column(TypeName = "varchar(255)")]
    public string? RefreshToken { get; set; }
    
    [Column(TypeName="date")]
    public DateTime? RefreshTokenExpiry { get; set; }
    
    public ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
}