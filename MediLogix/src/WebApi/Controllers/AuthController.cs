namespace MediLogix.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator, UserManager<ApplicationUser> userManager, IJwtService jwtService)
    : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<AuthResponseDto>> Register([FromBody] RegisterDto registerDto)
    {
        var command = new RegisterCommand { RegisterDto = registerDto };
        var result = await mediator.Send(command);

        if (!result.IsSuccessful)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginDto loginDto)
    {
        var command = new LoginCommand { LoginDto = loginDto };
        var result = await mediator.Send(command);

        if (!result.IsSuccessful)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("refresh-token")]
    public async Task<ActionResult<AuthResponseDto>> RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
    {
        var principal = jwtService.GetPrincipalFromExpiredToken(refreshTokenDto.AccessToken);
        var username = principal.Identity?.Name;
        
        var user = await userManager.FindByNameAsync(username);
        if (user == null || user.RefreshToken != refreshTokenDto.RefreshToken || 
            user.RefreshTokenExpiryTime <= DateTime.Now)
        {
            return BadRequest("Invalid refresh token request");
        }

        var roles = await userManager.GetRolesAsync(user);
        var newAccessToken = jwtService.GenerateAccessToken(user, roles);
        var newRefreshToken = jwtService.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        await userManager.UpdateAsync(user);

        return Ok(new AuthResponseDto
        {
            IsSuccessful = true,
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken,
            ExpiresIn = DateTime.Now.AddMinutes(15)
        });
    }

    [Authorize]
    [HttpPost("revoke-token")]
    public async Task<IActionResult> RevokeToken()
    {
        if (User.Identity == null) return NoContent();
        var username = User.Identity.Name;
        if (username == null) return NoContent();
        var user = await userManager.FindByNameAsync(username);
        if (user == null) return BadRequest();

        user.RefreshToken = null;
        await userManager.UpdateAsync(user);

        return NoContent();
    }
} 