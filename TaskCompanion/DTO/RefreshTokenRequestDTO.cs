namespace ToDoManager.DTO;

public class RefreshTokenRequestDTO
{
    public int UserId { get; set; }
    public required string refreshToken { get; set; }
}