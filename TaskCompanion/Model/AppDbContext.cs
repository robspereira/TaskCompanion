using Microsoft.EntityFrameworkCore;

namespace ToDoManager.Model;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Tasks>? Tasks { get; set; }
    
    public DbSet<User>? Users { get; set; }

}