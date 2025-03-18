namespace MediLogix.Application.Handlers.Commands.Employee;

public sealed class CreateEmployeeCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory, IMapper mapper)
    : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
{
    public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);

        var employee = new Domain.Entities.Employee
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Address = request.Address,
            City = request.City,
            Age = request.Age,
            JobName = request.JobName,
            UserId = request.UserId
        };

        await context.Employees.AddAsync(employee, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<EmployeeDto>(employee);
    }
} 