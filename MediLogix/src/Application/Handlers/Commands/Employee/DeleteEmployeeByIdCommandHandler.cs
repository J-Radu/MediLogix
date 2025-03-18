namespace MediLogix.Application.Handlers.Commands.Employee;

public sealed class DeleteEmployeeByIdCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteEmployeeByIdCommand, Unit>
{
    public async Task<Unit> Handle(DeleteEmployeeByIdCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var employee = await context.Employees
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (employee == null)
            throw new Exception("Employee not found");

        context.Employees.Remove(employee);
        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}