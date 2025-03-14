namespace MediLogix.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController(IMediator mediator) : ControllerBase
{
    #region Employee Endpoints
    [HttpGet]
    [ProducesResponseType(typeof(List<EmployeeDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<EmployeeDto>>> GetAllEmployees()
    {
        var query = new GetAllEmployeesQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmployeeDto>> GetEmployeeById(Guid id)
    {
        var query = new GetEmployeeByIdQuery { Id = id };
        var result = await mediator.Send(query);
        
        if (result == null)
            return NotFound();
            
        return Ok(result);
    }
    #endregion

    #region Activity Endpoints
    [HttpGet("activity")]
    [ProducesResponseType(typeof(List<ActivityDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ActivityDto>>> GetAllActivities()
    {
        var query = new GetAllActivitiesQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet("activity/{id:guid}")]
    [ProducesResponseType(typeof(ActivityDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ActivityDto>> GetActivityById(Guid id)
    {
        var query = new GetActivityByIdQuery { Id = id };
        var result = await mediator.Send(query);
        
        if (result == null)
            return NotFound();
            
        return Ok(result);
    }
    #endregion
}