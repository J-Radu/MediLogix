namespace MediLogix.Application.Queries.Device;

public class GetDeviceByIdQuery : IRequest<DeviceDto>
{
    public Guid Id { get; set; }
} 