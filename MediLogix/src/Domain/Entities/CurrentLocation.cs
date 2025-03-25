namespace MediLogix.Domain.Entities;

public sealed class CurrentLocation : EntityBase
{
    public string IMS { get; set; }
    public string Department { get; set; }
    public string Localization { get; set; }
    public string Status { get; set; }
    public Device? Device { get; set; }
}