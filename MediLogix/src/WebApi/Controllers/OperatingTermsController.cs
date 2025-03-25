namespace MediLogix.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin,User")]
public class OperatingTermsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
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

    [HttpGet]
    [ProducesResponseType(typeof(List<OperatingTermsDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<OperatingTermsDto>>> GetAllOperatingTerms()
    {
        var query = new GetAllOperatingTermsQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> CreateOperatingTerms([FromBody] CreateOperatingTermsCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetOperatingTermsById), new { id = result }, result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateOperatingTerms(Guid id, [FromBody] UpdateOperatingTermsCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteOperatingTerms(Guid id)
    {
        await mediator.Send(new DeleteOperatingTermsByIdCommand{ Id = id });
        return NoContent();
    }

    [HttpDelete("all")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAllOperatingTerms()
    {
        await mediator.Send(new DeleteAllOperatingTermsCommand());
        return NoContent();
    }
} 