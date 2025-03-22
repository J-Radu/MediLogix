namespace MediLogix.Application.Commands.Auth;

public class ResetPasswordCommand : IRequest<ResultDto>
{
    public string Email { get; set; }
    public string Token { get; set; }
    public string NewPassword { get; set; }
} 