namespace MediLogix.Application.Commands.Employee;

public sealed class CreateEmployeeCommand : IRequest<EmployeeDto>
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
} 