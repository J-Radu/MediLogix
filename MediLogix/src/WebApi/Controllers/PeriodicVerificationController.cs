namespace MediLogix.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin,User")]
public class PeriodicVerificationController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
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

    [HttpGet]
    [ProducesResponseType(typeof(List<PeriodicVerificationDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<PeriodicVerificationDto>>> GetAllPeriodicVerifications()
    {
        var query = new GetAllPeriodicVerificationsQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> CreatePeriodicVerification([FromBody] CreatePeriodicVerificationCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetPeriodicVerificationById), new { id = result }, result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdatePeriodicVerification(Guid id, [FromBody] UpdatePeriodicVerificationCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeletePeriodicVerification(Guid id)
    {
        await mediator.Send(new DeletePeriodicVerificationByIdCommand{ Id = id });
        return NoContent();
    }

    [HttpDelete("all")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAllPeriodicVerifications()
    {
        await mediator.Send(new DeleteAllPeriodicVerificationsCommand());
        return NoContent();
    }
} 