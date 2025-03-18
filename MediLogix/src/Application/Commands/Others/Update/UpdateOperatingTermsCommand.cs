namespace MediLogix.Application.Commands.Others.Update;

public abstract class UpdateOperatingTermsCommand : EntityBase, IRequest<OperatingTermsDto>
{
    public DateOnly ProductionDate { get; set; }
    public DateOnly DeliveryDate { get; set; }
    public DateOnly InstallationDate { get; set; }
    public DateOnly GuaranteeExpirationDate { get; set; }
    public DateOnly ExploitationTime { get; set; }
} 