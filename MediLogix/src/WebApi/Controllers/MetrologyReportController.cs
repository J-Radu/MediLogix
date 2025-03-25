namespace MediLogix.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin,User")]
public class MetrologyReportController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<MetrologyReportDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<MetrologyReportDto>>> GetAllMetrologyReports()
    {
        var query = new GetAllMetrologyReportsQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
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

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> CreateMetrologyReport([FromBody] CreateMetrologyReportCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetMetrologyReportById), new { id = result }, result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateMetrologyReport(Guid id, [FromBody] UpdateMetrologyReportCommand command)
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
    public async Task<ActionResult> DeleteMetrologyReport(Guid id)
    {
        await mediator.Send(new DeleteMetrologyReportByIdCommand{ Id = id });
        return NoContent();
    }

    [HttpDelete("all")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAllMetrologyReports()
    {
        await mediator.Send(new DeleteAllMetrologyReportsCommand());
        return NoContent();
    }
} 