using MediatR;
using MediLogix.Application.DTOs.Auth;

namespace MediLogix.Application.Commands.Auth;

public class LoginCommand : IRequest<AuthResponseDto>
{
    public LoginDto LoginDto { get; set; }
} 