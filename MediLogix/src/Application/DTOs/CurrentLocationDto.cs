namespace MediLogix.Application.DTOs;

public class CurrentLocationDto : EntityBase
{
    public string IMS { get; set; }
    public string Department { get; set; }
    public string Localization { get; set; }
    public string Status { get; set; }
}