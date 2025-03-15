namespace MediLogix.Application.DTOs.Auth;

public class AuthResponseDto
{
    public bool IsSuccessful { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime ExpiresIn { get; set; }
    public IEnumerable<string> Errors { get; set; }
} 