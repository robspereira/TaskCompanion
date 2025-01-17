using ToDoManager.DTO;
using ToDoManager.Model;

namespace ToDoManager.Interface;

public interface IUserAuthInterface

{
    Task<User?> RegisterAsync(UserDTO request);
    Task<TokenResponseDTO?> LoginAsync(UserDTO request);
    
    Task<TokenResponseDTO?> RefreshTokenAsync(RefreshTokenRequestDTO request);

}