namespace MediLogix.Application.Handlers.Commands.Auth;

public class RequestPasswordResetCommandHandler(UserManager<ApplicationUser> userManager, IEmailService emailService)
    : IRequestHandler<RequestPasswordResetCommand, ResultDto>
{
    public async Task<ResultDto> Handle(RequestPasswordResetCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return new ResultDto { IsSuccessful = true, Message = "Dacă emailul există, un link de resetare a fost trimis." };
        }

        var token = await userManager.GeneratePasswordResetTokenAsync(user);
        
        await emailService.SendPasswordResetEmailAsync(user.Email, token);

        return new ResultDto { IsSuccessful = true, Message = "Dacă emailul există, un link de resetare a fost trimis." };
    }
} 