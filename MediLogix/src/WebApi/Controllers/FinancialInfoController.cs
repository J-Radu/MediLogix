namespace MediLogix.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin,User")]
public class FinancialInfoController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
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

    [HttpGet]
    [ProducesResponseType(typeof(List<FinancialInfoDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<FinancialInfoDto>>> GetAllFinancialInfos()
    {
        var query = new GetAllFinancialInfosQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> CreateFinancialInfo([FromBody] CreateFinancialInfoCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetFinancialInfoById), new { id = result }, result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateFinancialInfo(Guid id, [FromBody] UpdateFinancialInfoCommand command)
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
    public async Task<ActionResult> DeleteFinancialInfo(Guid id)
    {
        await mediator.Send(new DeleteFinancialInfoByIdCommand{ Id = id });
        return NoContent();
    }

    [HttpDelete("all")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAllFinancialInfos()
    {
        await mediator.Send(new DeleteAllFinancialInfosCommand());
        return NoContent();
    }
} 