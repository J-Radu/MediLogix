namespace MediLogix.Domain.Entities;

public class Model : EntityBase
{
    public string DmModel { get; set; }
    public string GMDN { get; set; }
    public string Manufacturer { get; set; }
    public string Country { get; set; }
    public virtual Device Device { get; set; }
}