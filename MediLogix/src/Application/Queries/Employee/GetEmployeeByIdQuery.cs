namespace MediLogix.Application.Queries.Employee;

public class GetEmployeeByIdQuery : IRequest<EmployeeDto>
{
    public Guid Id { get; set; }
} 