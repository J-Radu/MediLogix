namespace MediLogix.Domain.Entities;

public class Piece : EntityBase
{
    public Guid DeviceId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public DateOnly AcquisitionDate { get; set; }
    public virtual Device Device { get; set; }
}