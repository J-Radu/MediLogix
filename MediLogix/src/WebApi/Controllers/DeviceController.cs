namespace MediLogix.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeviceController(IMediator mediator) : ControllerBase
{
    #region Device Endpoints
    [HttpGet]
    [ProducesResponseType(typeof(List<DeviceDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<DeviceDto>>> GetAll()
    {
        var query = new GetAllDevicesQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(DeviceDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DeviceDto>> GetById(Guid id)
    {
        var query = new GetDeviceByIdQuery { Id = id };
        var result = await mediator.Send(query);
        
        if (result == null)
            return NotFound();
            
        return Ok(result);
    }
    #endregion

    #region Model Endpoints
    [HttpGet("model/{id:guid}")]
    [ProducesResponseType(typeof(ModelDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ModelDto>> GetModelById(Guid id)
    {
        var query = new GetModelByIdQuery { Id = id };
        var result = await mediator.Send(query);
        
        if (result == null)
            return NotFound();
            
        return Ok(result);
    }
    #endregion

    #region FinancialInfo Endpoints
    [HttpGet("financial-info/{id:guid}")]
    [ProducesResponseType(typeof(FinancialInfoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FinancialInfoDto>> GetFinancialInfoById(Guid id)
    {
        var query = new GetFinancialInfoByIdQuery { Id = id };
        var result = await mediator.Send(query);
        
        if (result == null)
            return NotFound();
            
        return Ok(result);
    }
    #endregion

    #region CurrentLocation Endpoints
    [HttpGet("current-location/{id:guid}")]
    [ProducesResponseType(typeof(CurrentLocationDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CurrentLocationDto>> GetCurrentLocationById(Guid id)
    {
        var query = new GetCurrentLocationByIdQuery { Id = id };
        var result = await mediator.Send(query);
        
        if (result == null)
            return NotFound();
            
        return Ok(result);
    }
    #endregion

    #region PeriodicVerification Endpoints
    [HttpGet("periodic-verification/{id:guid}")]
    [ProducesResponseType(typeof(PeriodicVerificationDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PeriodicVerificationDto>> GetPeriodicVerificationById(Guid id)
    {
        var query = new GetPeriodicVerificationByIdQuery { Id = id };
        var result = await mediator.Send(query);
        
        if (result == null)
            return NotFound();
            
        return Ok(result);
    }
    #endregion

    #region WarrantyAndMaintenance Endpoints
    [HttpGet("warranty-maintenance/{id:guid}")]
    [ProducesResponseType(typeof(WarrantyAndMaintenanceDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WarrantyAndMaintenanceDto>> GetWarrantyAndMaintenanceById(Guid id)
    {
        var query = new GetWarrantyAndMaintenanceByIdQuery { Id = id };
        var result = await mediator.Send(query);
        
        if (result == null)
            return NotFound();
            
        return Ok(result);
    }
    #endregion

    #region Description Endpoints
    [HttpGet("description/{id:guid}")]
    [ProducesResponseType(typeof(DescriptionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DescriptionDto>> GetDescriptionById(Guid id)
    {
        var query = new GetDescriptionByIdQuery { Id = id };
        var result = await mediator.Send(query);
        
        if (result == null)
            return NotFound();
            
        return Ok(result);
    }
    #endregion

    #region OperatingTerms Endpoints
    [HttpGet("operating-terms/{id:guid}")]
    [ProducesResponseType(typeof(OperatingTermsDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OperatingTermsDto>> GetOperatingTermsById(Guid id)
    {
        var query = new GetOperatingTermsByIdQuery { Id = id };
        var result = await mediator.Send(query);
        
        if (result == null)
            return NotFound();
            
        return Ok(result);
    }
    #endregion

    #region Piece Endpoints
    [HttpGet("piece/{id:guid}")]
    [ProducesResponseType(typeof(PieceDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PieceDto>> GetPieceById(Guid id)
    {
        var query = new GetPieceByIdQuery { Id = id };
        var result = await mediator.Send(query);
        
        if (result == null)
            return NotFound();
            
        return Ok(result);
    }
    #endregion

    #region MetrologyReport Endpoints
    [HttpGet("metrology-report")]
    [ProducesResponseType(typeof(List<MetrologyReportDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<MetrologyReportDto>>> GetAllMetrologyReports()
    {
        var query = new GetAllMetrologyReportsQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet("metrology-report/{id:guid}")]
    [ProducesResponseType(typeof(MetrologyReportDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MetrologyReportDto>> GetMetrologyReportById(Guid id)
    {
        var query = new GetMetrologyReportByIdQuery { Id = id };
        var result = await mediator.Send(query);
        
        if (result == null)
            return NotFound();
            
        return Ok(result);
    }
    #endregion

    #region Failure Endpoints
    [HttpGet("failure")]
    [ProducesResponseType(typeof(List<FailureDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<FailureDto>>> GetAllFailures()
    {
        var query = new GetAllFailuresQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet("failure/{id:guid}")]
    [ProducesResponseType(typeof(FailureDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FailureDto>> GetFailureById(Guid id)
    {
        var query = new GetFailureByIdQuery { Id = id };
        var result = await mediator.Send(query);
        
        if (result == null)
            return NotFound();
            
        return Ok(result);
    }
    #endregion
} 