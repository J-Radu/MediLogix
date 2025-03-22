namespace MediLogix.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin,User")]
public class PieceController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PieceDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PieceDto>> GetPieceById(Guid id)
    {
        var query = new GetPieceByIdQuery { Id = id };
        var result = await mediator.Send(query);
        
        if (result == null)
            return NotFound();
            
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<PieceDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<PieceDto>>> GetAllPieces()
    {
        var query = new GetAllPiecesQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> CreatePiece([FromBody] CreatePieceCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetPieceById), new { id = result }, result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdatePiece(Guid id, [FromBody] UpdatePieceCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeletePiece(Guid id)
    {
        await mediator.Send(new DeletePieceByIdCommand{ Id = id });
        return NoContent();
    }

    [HttpDelete("all")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAllPieces()
    {
        await mediator.Send(new DeleteAllPiecesCommand());
        return NoContent();
    }
} 