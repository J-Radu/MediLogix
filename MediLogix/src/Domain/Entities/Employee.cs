namespace MediLogix.Domain.Entities;

public class Employee : EntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public int Age { get; set; }
    public string JobName { get; set; }
    public Guid UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<Device>? Devices { get; set; }
    public virtual ICollection<Activity>? Activities { get; set; }
}