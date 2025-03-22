namespace MediLogix.Application.DTOs.Auth;

public class RequestPasswordResetDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
} 