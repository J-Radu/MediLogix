namespace MediLogix.Application.DTOs;

public sealed class PieceDto : EntityBase
{
    public Guid DeviceId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public DateOnly AcquisitionDate { get; set; }
}