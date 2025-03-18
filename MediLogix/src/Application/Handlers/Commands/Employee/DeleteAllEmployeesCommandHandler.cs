namespace MediLogix.Application.Handlers.Commands.Employee;

public sealed class DeleteAllEmployeesCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteAllEmployeesCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAllEmployeesCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.Employees
            .ExecuteDeleteAsync(cancellationToken);

        return Unit.Value;
    }
} 