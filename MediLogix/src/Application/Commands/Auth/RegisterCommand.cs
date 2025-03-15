using MediatR;
using MediLogix.Application.DTOs.Auth;

namespace MediLogix.Application.Commands.Auth;

public class RegisterCommand : IRequest<AuthResponseDto>
{
    public RegisterDto RegisterDto { get; set; }
} 