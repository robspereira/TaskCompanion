using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoManager.Model;

public class User
{
    [Key]
    public int Id { get; set; }
    
    [Column(TypeName = "varchar(30)")]
    public string Username { get; set; } = string.Empty;
    
    [Column(TypeName = "varchar(255)")]
    public string PasswordHash { get; set; } = string.Empty;
    
    [Column(TypeName = "varchar(30)")]
    public string Role { get; set; } = string.Empty;
    
    [Column(TypeName = "varchar(255)")]
    public string? RefreshToken { get; set; }
    
    [Column(TypeName="date")]
    public DateTime? RefreshTokenExpiry { get; set; }
}