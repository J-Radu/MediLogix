using MediLogix.Infrastructure.Persistence.Interfaces;

namespace MediLogix.Application.Handlers.Commands.Auth;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResponseDto>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJwtService _jwtService;

    public RegisterCommandHandler(UserManager<ApplicationUser> userManager, IJwtService jwtService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
    }

    public async Task<AuthResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userManager.FindByEmailAsync(request.RegisterDto.Email);
        if (userExists != null)
        {
            return new AuthResponseDto
            {
                IsSuccessful = false,
                Errors = new[] { "User already exists!" }
            };
        }

        var user = new ApplicationUser
        {
            Email = request.RegisterDto.Email,
            UserName = request.RegisterDto.Email,
            Employee = new Employee
            {
                FirstName = request.RegisterDto.FirstName,
                LastName = request.RegisterDto.LastName,
                Email = request.RegisterDto.Email,
                PhoneNumber = request.RegisterDto.PhoneNumber,
                Address = request.RegisterDto.Address,
                City = request.RegisterDto.City,
                Age = request.RegisterDto.Age,
                JobName = request.RegisterDto.JobName
            }
        };

        var result = await _userManager.CreateAsync(user, request.RegisterDto.Password);
        if (!result.Succeeded)
        {
            return new AuthResponseDto
            {
                IsSuccessful = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        await _userManager.AddToRoleAsync(user, "Employee");

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