using Microsoft.AspNetCore.Mvc;
using Bunker.Api.Handlers.Voyage;
using Bunker.Api.Handlers.Voyage.DTOs;
using MediatR;
using Bunker.Api.Handlers._Shared;

namespace Bunker.Api.Controllers;

[Route("api/voyages")]
[ApiController]
public class VoyageController(ILogger<VoyageController> logger, IMediator mediator) : ApiControllerBase(logger, mediator)
{
    [HttpPost("create")]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateVoyage(
        [FromBody] CreateVoyageCommand request,
        CancellationToken cancellationToken = default)
    {
        return await HandleCommandAsync(request, cancellationToken);
    }

    [HttpGet("get-all")]
    [ProducesResponseType(typeof(GetAllVoyagesResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(QueryApiResponse<GetAllVoyagesResponse>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllVoyages(
        [FromQuery] GetAllVoyagesQuery request,
        CancellationToken cancellationToken = default)
    {
        return await HandleQueryAsync(request, cancellationToken);
    }

    [HttpGet("get-by-id/{id}")]
    [ProducesResponseType(typeof(GetVoyageByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(QueryApiResponse<GetVoyageByIdResponse>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(QueryApiResponse<GetVoyageByIdResponse>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetVoyageById(
        int id,
        CancellationToken cancellationToken = default)
    {
        var request = new GetVoyageByIdQuery { Id = id };
        return await HandleQueryAsync(request, cancellationToken);
    }

    [HttpPut("update/{id}")]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateVoyage(
        int id,
        [FromBody] UpdateVoyageCommand request,
        CancellationToken cancellationToken = default)
    {
        request.Voyage.Id = id;
        return await HandleCommandAsync(request, cancellationToken);
    }

    [HttpDelete("delete/{id}")]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteVoyage(
        int id,
        CancellationToken cancellationToken = default)
    {
        var request = new DeleteVoyageCommand { Id = id };
        return await HandleCommandAsync(request, cancellationToken);
    }
}
