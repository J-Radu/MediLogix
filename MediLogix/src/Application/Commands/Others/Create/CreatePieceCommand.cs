namespace MediLogix.Application.Commands.Others.Create;

public sealed class CreatePieceCommand : IRequest<PieceDto>
{
    public Guid DeviceId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public DateOnly AcquisitionDate { get; set; }
} 