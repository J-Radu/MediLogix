using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;

namespace MediLogix.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator, UserManager<ApplicationUser> userManager, IJwtService jwtService, IConfiguration configuration)
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

    [HttpPost("request-password-reset")]
    public async Task<IActionResult> RequestPasswordReset([FromBody] RequestPasswordResetDto requestDto)
    {
        var command = new RequestPasswordResetCommand { Email = requestDto.Email };
        var result = await mediator.Send(command);

        if (!result.IsSuccessful)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetDto)
    {
        var command = new ResetPasswordCommand 
        { 
            Email = resetDto.Email,
            Token = resetDto.Token,
            NewPassword = resetDto.NewPassword
        };
        
        var result = await mediator.Send(command);

        if (!result.IsSuccessful)
            return BadRequest(result);

        return Ok(result);
    }
    
    [Authorize]
    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
    {
        if (User.Identity == null) return Unauthorized();
        var username = User.Identity.Name;
        if (username == null) return Unauthorized();
        
        var command = new ChangePasswordCommand 
        { 
            Username = username,
            CurrentPassword = changePasswordDto.CurrentPassword,
            NewPassword = changePasswordDto.NewPassword
        };
        
        var result = await mediator.Send(command);

        if (!result.IsSuccessful)
            return BadRequest(result);

        return Ok(result);
    }
    
    [Authorize]
    [HttpGet("test-auth")]
    public IActionResult TestAuth()
    {
        var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();
        var roles = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
        
        return Ok(new { 
            IsAuthenticated = User.Identity?.IsAuthenticated ?? false,
            UserName = User.Identity?.Name,
            AuthenticationType = User.Identity?.AuthenticationType,
            Claims = claims,
            Roles = roles
        });
    }

    [HttpGet("debug-token")]
    public IActionResult GetDebugToken()
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            claims: new[] { 
                new Claim(ClaimTypes.Name, "debug-user"),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, "User")
            },
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );
        
        return Ok(new { 
            token = new JwtSecurityTokenHandler().WriteToken(token),
            expires = DateTime.Now.AddDays(1)
        });
    }
} 