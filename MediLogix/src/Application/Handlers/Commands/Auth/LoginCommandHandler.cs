using MediLogix.Infrastructure.Persistence.Interfaces;

namespace MediLogix.Application.Handlers.Commands.Auth;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponseDto>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJwtService _jwtService;

    public LoginCommandHandler(UserManager<ApplicationUser> userManager, IJwtService jwtService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
    }

    public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.LoginDto.Email);
        if (user == null)
        {
            return new AuthResponseDto
            {
                IsSuccessful = false,
                Errors = new[] { "Invalid credentials" }
            };
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.LoginDto.Password);
        if (!isPasswordValid)
        {
            return new AuthResponseDto
            {
                IsSuccessful = false,
                Errors = new[] { "Invalid credentials" }
            };
        }

        var roles = await _userManager.GetRolesAsync(user);
        var accessToken = _jwtService.GenerateAccessToken(user, roles);
        var refreshToken = _jwtService.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
        await _userManager.UpdateAsync(user);

        return new AuthResponseDto
        {
            IsSuccessful = true,
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            ExpiresIn = DateTime.Now.AddMinutes(15)
        };
    }
} 