namespace MediLogix.Application.Commands.Auth;

public class ChangePasswordCommand : IRequest<ResultDto>
{
    public string Username { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
} 