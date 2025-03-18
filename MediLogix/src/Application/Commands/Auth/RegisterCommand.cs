namespace MediLogix.Application.Commands.Auth;

public class RegisterCommand : IRequest<AuthResponseDto>
{
    public RegisterDto RegisterDto { get; set; }
} 