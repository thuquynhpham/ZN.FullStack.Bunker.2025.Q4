using Bunker.Api.Handlers._Shared;
using Bunker.Api.Handlers.PortCall;
using Bunker.Api.Handlers.PortCall.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bunker.Api.Controllers;

[Route("api/port-calls")]
[ApiController]
public class PortCallController(ILogger<PortCallController> logger, IMediator mediator) : ApiControllerBase(logger, mediator)
{
    [HttpPost("create")]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreatePortCall(
        [FromBody] CreatePortCallCommand request,
        CancellationToken cancellationToken = default)
    {
        return await HandleCommandAsync(request, cancellationToken);
    }

    [HttpGet("get-all")]
    [ProducesResponseType(typeof(GetAllPortCallsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(QueryApiResponse<GetAllPortCallsResponse>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllPortCalls(
        [FromQuery] GetAllPortCallsQuery request,
        CancellationToken cancellationToken = default)
    {
        return await HandleQueryAsync(request, cancellationToken);
    }

    [HttpGet("get-by-id/{id}")]
    [ProducesResponseType(typeof(GetPortCallByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(QueryApiResponse<GetPortCallByIdResponse>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(QueryApiResponse<GetPortCallByIdResponse>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPortCallById(
        int id,
        CancellationToken cancellationToken = default)
    {
        var request = new GetPortCallByIdQuery { Id = id };
        return await HandleQueryAsync(request, cancellationToken);
    }

    [HttpPut("update/{id}")]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdatePortCall(
        int id,
        [FromBody] UpdatePortCallCommand request,
        CancellationToken cancellationToken = default)
    {
        request.PortCall.Id = id;
        return await HandleCommandAsync(request, cancellationToken);
    }

    [HttpDelete("delete/{id}")]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeletePortCall(
        int id,
        CancellationToken cancellationToken = default)
    {
        var request = new DeletePortCallCommand(id);
        return await HandleCommandAsync(request, cancellationToken);
    }
}
