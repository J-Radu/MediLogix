namespace MediLogix.Application.Commands.Others.Update;

public abstract class UpdatePieceCommand : EntityBase, IRequest<PieceDto>
{
    public Guid DeviceId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public DateOnly AcquisitionDate { get; set; }
} 