namespace MediLogix.Application.Handlers.Commands.Auth;

public class ChangePasswordCommandHandler(UserManager<ApplicationUser> userManager)
    : IRequestHandler<ChangePasswordCommand, ResultDto>
{
    public async Task<ResultDto> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(request.Username);
        if (user == null)
        {
            return new ResultDto { IsSuccessful = false, Message = "User not found." };
        }

        var result = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

        if (!result.Succeeded)
        {
            return new ResultDto 
            { 
                IsSuccessful = false, 
                Message = "Password change failed.",
                Errors = result.Errors.Select(e => e.Description).ToList()
            };
        }

        return new ResultDto { IsSuccessful = true, Message = "Password successfully changed." };
    }
} 