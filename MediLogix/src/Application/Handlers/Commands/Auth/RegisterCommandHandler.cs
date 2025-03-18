namespace MediLogix.Application.Handlers.Commands.Auth;

public class RegisterCommandHandler(UserManager<ApplicationUser> userManager, IJwtService jwtService)
    : IRequestHandler<RegisterCommand, AuthResponseDto>
{
    public async Task<AuthResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var userExists = await userManager.FindByEmailAsync(request.RegisterDto.Email);
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
            Employee = new Domain.Entities.Employee
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

        var result = await userManager.CreateAsync(user, request.RegisterDto.Password);
        if (!result.Succeeded)
        {
            return new AuthResponseDto
            {
                IsSuccessful = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        await userManager.AddToRoleAsync(user, "Employee");

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