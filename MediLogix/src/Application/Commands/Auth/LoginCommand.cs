namespace MediLogix.Application.Commands.Auth;

public class LoginCommand : IRequest<AuthResponseDto>
{
    public LoginDto LoginDto { get; set; }
} 