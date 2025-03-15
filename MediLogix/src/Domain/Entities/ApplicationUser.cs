using Microsoft.AspNetCore.Identity;

namespace MediLogix.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public virtual Employee Employee { get; set; }
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
} 