namespace MediLogix.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin,User")]
public class DeviceController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<FullDeviceDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<FullDeviceDto>>> GetAll()
    {
        var query = new GetAllFullDevicesQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(FullDeviceDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FullDeviceDto>> GetById(Guid id)
    {
        var query = new GetFullDeviceByIdQuery { Id = id };
        var result = await mediator.Send(query);
        
        if (result == null)
            return NotFound();
            
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> CreateDevice([FromBody] CreateFullDeviceCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result }, result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateDevice(Guid id, [FromBody] UpdateFullDeviceCommand command)
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
    public async Task<ActionResult> DeleteDevice(Guid id)
    {
        await mediator.Send(new DeleteFullDeviceByIdCommand{ Id = id });
        return NoContent();
    }

    [HttpDelete("all")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAllDevices()
    {
        await mediator.Send(new DeleteAllFullDevicesCommand());
        return NoContent();
    }
} 