namespace MediLogix.Application.Handlers.Commands.Auth;

public class ResetPasswordCommandHandler(UserManager<ApplicationUser> userManager)
    : IRequestHandler<ResetPasswordCommand, ResultDto>
{
    public async Task<ResultDto> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return new ResultDto { IsSuccessful = false, Message = "User not found." };
        }

        var result = await userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);

        if (!result.Succeeded)
        {
            return new ResultDto 
            { 
                IsSuccessful = false, 
                Message = "Password reset failed.",
                Errors = result.Errors.Select(e => e.Description).ToList()
            };
        }

        return new ResultDto { IsSuccessful = true, Message = "Password successfully reset." };
    }
} 