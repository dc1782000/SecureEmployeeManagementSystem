using SecureEmployeeManagementSystem.Application.Interfaces;
using SecureEmployeeManagementSystem.Application.DTOs.Auth;
using SecureEmployeeManagementSystem.Application.Interfaces;
namespace SecureEmployeeManagementSystem.Application.Services;

public class AuthService: IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IPasswordHasher _passwordHasher;
    public AuthService(
        IUserRepository userRepository,
        IJwtTokenService jwtTokenService,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
        _passwordHasher = passwordHasher;
    }
    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
    {
        var user = await _userRepository
            .GetByUsernameAsync(request.Username);
        if (user == null)
            throw new Exception("Invalid username or password");
        var validPassword =
            _passwordHasher.Verify(
                request.Password,
                user.PasswordHash);
        if (!validPassword)
            throw new Exception("Invalid username or password");
        var token =
            _jwtTokenService.GenerateToken(user);
        return new LoginResponseDto
        {
            Token = token,
            Username = user.Username,
            Role = user.Role
        };
    }
}