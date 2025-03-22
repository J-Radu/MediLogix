namespace MediLogix.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin,User")]
public class FailureController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<FailureDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<FailureDto>>> GetAllFailures()
    {
        var query = new GetAllFailuresQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
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

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> CreateFailure([FromBody] CreateFailureCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetFailureById), new { id = result }, result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateFailure(Guid id, [FromBody] UpdateFailureCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteFailure(Guid id)
    {
        await mediator.Send(new DeleteFailureByIdCommand{ Id = id });
        return NoContent();
    }

    [HttpDelete("all")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAll()
    {
        await mediator.Send(new DeleteAllFailuresCommand());
        return NoContent();
    }
} 