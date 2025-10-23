using Microsoft.AspNetCore.Mvc;
using Bunker.Api.Handlers.Vessel;
using Bunker.Api.Handlers.Vessel.DTOs;
using MediatR;
using Bunker.Api.Handlers._Shared;

namespace Bunker.Api.Controllers;

[Route("api/vessels")]
[ApiController]
public class VesselController : ApiControllerBase
{
    public VesselController(ILogger<VesselController> logger, IMediator mediator) 
        : base(logger, mediator)
    {
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateVessel(
        [FromBody] CreateVesselCommand request,
        CancellationToken cancellationToken = default)
    {
        return await HandleCommandAsync(request, cancellationToken);
    }

    [HttpGet("get-all")]
    [ProducesResponseType(typeof(GetAllVesselsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(QueryApiResponse<GetAllVesselsResponse>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllVessels(
        [FromQuery] GetAllVesselsQuery request,
        CancellationToken cancellationToken = default)
    {
        return await HandleQueryAsync(request, cancellationToken);
    }

    [HttpGet("get-by-id/{id}")]
    [ProducesResponseType(typeof(GetVesselByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(QueryApiResponse<GetVesselByIdResponse>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(QueryApiResponse<GetVesselByIdResponse>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetVesselById(
        int id,
        CancellationToken cancellationToken = default)
    {
        var request = new GetVesselByIdQuery { Id = id };
        return await HandleQueryAsync(request, cancellationToken);
    }

    [HttpPut("update/{id}")]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateVessel(
        int id,
        [FromBody] UpdateVesselCommand request,
        CancellationToken cancellationToken = default)
    {
        request.Vessel.Id = id;
        return await HandleCommandAsync(request, cancellationToken);
    }

    [HttpDelete("delete/{id}")]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteVessel(
        int id,
        CancellationToken cancellationToken = default)
    {
        var request = new DeleteVesselCommand { Id = id };
        return await HandleCommandAsync(request, cancellationToken);
    }
}
