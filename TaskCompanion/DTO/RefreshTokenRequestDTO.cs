namespace ToDoManager.DTO;

public class RefreshTokenRequestDTO
{
    public Guid UserId { get; set; }
    public required string refreshToken { get; set; }
}