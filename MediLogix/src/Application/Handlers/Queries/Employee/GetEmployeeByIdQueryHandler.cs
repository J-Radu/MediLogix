namespace MediLogix.Application.Handlers.Queries.Employee;

public class GetEmployeeByIdQueryHandler(IMediLogixDbContext context)
    : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
{
    public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await context.Employees
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        if (employee == null)
        {
            return null;
        }

        return new EmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber,
            Address = employee.Address,
            City = employee.City,
            Age = employee.Age,
            JobName = employee.JobName,
            UserId = employee.UserId
        };
    }
} 