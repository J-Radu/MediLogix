namespace MediLogix.Application.Handlers.Commands.Auth;

public class LoginCommandHandler(UserManager<ApplicationUser> userManager, IJwtService jwtService)
    : IRequestHandler<LoginCommand, AuthResponseDto>
{
    public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.LoginDto.Email);
        if (user == null)
        {
            return new AuthResponseDto
            {
                IsSuccessful = false,
                Errors = ["Invalid credentials"]
            };
        }

        var isPasswordValid = await userManager.CheckPasswordAsync(user, request.LoginDto.Password);
        if (!isPasswordValid)
        {
            return new AuthResponseDto
            {
                IsSuccessful = false,
                Errors = ["Invalid credentials"]
            };
        }

        var roles = await userManager.GetRolesAsync(user);
        var accessToken = jwtService.GenerateAccessToken(user, roles);
        var refreshToken = jwtService.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
        await userManager.UpdateAsync(user);

        return new AuthResponseDto
        {
            IsSuccessful = true,
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            ExpiresIn = DateTime.Now.AddMinutes(15)
        };
    }
} 