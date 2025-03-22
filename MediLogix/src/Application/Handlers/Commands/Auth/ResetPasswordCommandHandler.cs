namespace MediLogix.Application.Handlers.Commands.Auth;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ResultDto>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ResetPasswordCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ResultDto> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return new ResultDto { IsSuccessful = false, Message = "Utilizatorul nu a fost găsit." };
        }

        var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);

        if (!result.Succeeded)
        {
            return new ResultDto 
            { 
                IsSuccessful = false, 
                Message = "Resetarea parolei a eșuat.",
                Errors = result.Errors.Select(e => e.Description).ToList()
            };
        }

        return new ResultDto { IsSuccessful = true, Message = "Parola a fost resetată cu succes." };
    }
} 