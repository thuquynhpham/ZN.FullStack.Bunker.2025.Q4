using Microsoft.AspNetCore.Mvc;
using Bunker.Api.Handlers.Port;
using Bunker.Api.Handlers.Port.DTOs;
using MediatR;
using Bunker.Api.Handlers._Shared;

namespace Bunker.Api.Controllers;

[Route("api/ports")]
[ApiController]
public class PortController : ApiControllerBase
{
    public PortController(ILogger<PortController> logger, IMediator mediator) 
        : base(logger, mediator)
    {
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreatePort(
        [FromBody] CreatePortCommand request,
        CancellationToken cancellationToken = default)
    {
        return await HandleCommandAsync(request, cancellationToken);
    }

    [HttpGet("get-all")]
    [ProducesResponseType(typeof(GetAllPortsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(QueryApiResponse<GetAllPortsResponse>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllPorts(
        [FromQuery] GetAllPortsQuery request,
        CancellationToken cancellationToken = default)
    {
        return await HandleQueryAsync(request, cancellationToken);
    }

    [HttpGet("get-by-id/{id}")]
    [ProducesResponseType(typeof(GetPortByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(QueryApiResponse<GetPortByIdResponse>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(QueryApiResponse<GetPortByIdResponse>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPortById(
        int id,
        CancellationToken cancellationToken = default)
    {
        var request = new GetPortByIdQuery { Id = id };
        return await HandleQueryAsync(request, cancellationToken);
    }

    [HttpPut("update/{id}")]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdatePort(
        int id,
        [FromBody] UpdatePortCommand request,
        CancellationToken cancellationToken = default)
    {
        request.Port.Id = id;
        return await HandleCommandAsync(request, cancellationToken);
    }

    [HttpDelete("delete/{id}")]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeletePort(
        int id,
        CancellationToken cancellationToken = default)
    {
        var request = new DeletePortCommand { Id = id };
        return await HandleCommandAsync(request, cancellationToken);
    }
}
