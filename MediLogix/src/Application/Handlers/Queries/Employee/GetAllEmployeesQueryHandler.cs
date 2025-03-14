namespace MediLogix.Application.Handlers.Queries.Employee;

public class GetAllEmployeesQueryHandler(IMediLogixDbContext context)
    : IRequestHandler<GetAllEmployeesQuery, List<EmployeeDto>>
{
    public async Task<List<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await context.Employees
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return employees.Select(e => new EmployeeDto
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Email = e.Email,
            PhoneNumber = e.PhoneNumber,
            Address = e.Address,
            City = e.City,
            Age = e.Age,
            JobName = e.JobName,
            UserId = e.UserId
        }).ToList();
    }
} 