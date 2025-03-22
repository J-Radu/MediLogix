namespace MediLogix.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin,User")]
public class DescriptionController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
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

    [HttpGet]
    [ProducesResponseType(typeof(List<DescriptionDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<DescriptionDto>>> GetAllDescriptions()
    {
        var query = new GetAllDescriptionsQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateDescriptionCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetDescriptionById), new { id = result }, result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateDescription(Guid id, [FromBody] UpdateDescriptionCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteDescription(Guid id)
    {
        await mediator.Send(new DeleteDescriptionByIdCommand{ Id = id });
        return NoContent();
    }

    [HttpDelete("all")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAllDescriptions()
    {
        await mediator.Send(new DeleteAllDescriptionsCommand());
        return NoContent();
    }
} 