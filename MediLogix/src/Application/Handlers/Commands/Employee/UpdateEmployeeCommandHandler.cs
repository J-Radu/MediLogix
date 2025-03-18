namespace MediLogix.Application.Handlers.Commands.Employee;

public sealed class UpdateEmployeeCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory, IMapper mapper)
    : IRequestHandler<UpdateEmployeeCommand, EmployeeDto>
{
    public async Task<EmployeeDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);

        var employee = await context.Employees.FindAsync([request.Id], cancellationToken);
        
        if (employee == null)
            throw new Exception("Employee not found");

        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.Email = request.Email;
        employee.PhoneNumber = request.PhoneNumber;
        employee.Address = request.Address;
        employee.City = request.City;
        employee.Age = request.Age;
        employee.JobName = request.JobName;
        employee.UserId = request.UserId;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<EmployeeDto>(employee);
    }
} 