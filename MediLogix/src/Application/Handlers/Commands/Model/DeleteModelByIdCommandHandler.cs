namespace MediLogix.Application.Handlers.Commands.Model;

public sealed class DeleteModelByIdCommandHandler(IDbContextFactory<MediLogixDbContext> contextFactory)
    : IRequestHandler<DeleteModelByIdCommand, Unit>
{
    public async Task<Unit> Handle(DeleteModelByIdCommand request, CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.Models
            .Where(x => x.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken);
        return Unit.Value;
    }
} 