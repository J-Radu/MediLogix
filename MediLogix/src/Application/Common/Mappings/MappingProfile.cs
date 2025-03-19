namespace MediLogix.Application.Common.Mappings;

public class MappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Domain.Entities.Employee, DTOs.EmployeeDto>();
        config.NewConfig<Domain.Entities.Device, DTOs.DeviceDto>();
    }
} 