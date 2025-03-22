namespace MediLogix.Application.Commands.Auth;

public class RequestPasswordResetCommand : IRequest<ResultDto>
{
    public string Email { get; set; }
} 