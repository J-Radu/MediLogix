using MediLogix.Application.Commands.Activity;
using MediLogix.Application.Commands.Employee;

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

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> CreateEmployee([FromBody] CreateEmployeeCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = result }, result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateEmployee(Guid id, [FromBody] UpdateEmployeeCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteEmployee(Guid id)
    {
        await mediator.Send(new DeleteEmployeeByIdCommand{ Id = id });
        return NoContent();
    }

    [HttpDelete("all")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAllEmployees()
    {
        await mediator.Send(new DeleteAllEmployeesCommand());
        return NoContent();
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

    [HttpPost("activity")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> CreateActivity([FromBody] CreateActivityCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetActivityById), new { id = result }, result);
    }

    [HttpPut("activity/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateActivity(Guid id, [FromBody] UpdateActivityCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("activity/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteActivity(Guid id)
    {
        await mediator.Send(new DeleteActivityByIdCommand { Id = id });
        return NoContent();
    }

    [HttpDelete("activity/all")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAllActivities()
    {
        await mediator.Send(new DeleteAllActivitiesCommand());
        return NoContent();
    }
    #endregion
}