namespace MediLogix.Domain.Entities;

public sealed class Employee : EntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public int Age { get; set; }
    public string JobName { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    public ICollection<Device>? Devices { get; set; }
    public ICollection<Activity>? Activities { get; set; }
}