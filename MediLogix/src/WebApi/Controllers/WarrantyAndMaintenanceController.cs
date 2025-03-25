namespace MediLogix.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin,User")]
public class WarrantyAndMaintenanceController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
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

    [HttpGet]
    [ProducesResponseType(typeof(List<WarrantyAndMaintenanceDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<WarrantyAndMaintenanceDto>>> GetAllWarrantyAndMaintenances()
    {
        var query = new GetAllWarrantyAndMaintenancesQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> CreateWarrantyAndMaintenance([FromBody] CreateWarrantyAndMaintenanceCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetWarrantyAndMaintenanceById), new { id = result }, result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateWarrantyAndMaintenance(Guid id, [FromBody] UpdateWarrantyAndMaintenanceCommand command)
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
    public async Task<ActionResult> DeleteWarrantyAndMaintenance(Guid id)
    {
        await mediator.Send(new DeleteWarrantyAndMaintenanceByIdCommand{ Id = id });
        return NoContent();
    }

    [HttpDelete("all")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAllWarrantyAndMaintenances()
    {
        await mediator.Send(new DeleteAllWarrantyAndMaintenancesCommand());
        return NoContent();
    }
} 