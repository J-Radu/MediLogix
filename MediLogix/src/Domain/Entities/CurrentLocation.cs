namespace MediLogix.Domain.Entities;

public class CurrentLocation : EntityBase
{
    public string IMS { get; set; }
    public string Department { get; set; }
    public string Localization { get; set; }
    public string Status { get; set; }
    public virtual Device Device { get; set; }
}