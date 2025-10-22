using Microsoft.AspNetCore.Mvc;
using Bunker.Api.Handlers.BunkerOrder;
using Bunker.Api.Handlers.BunkerOrder.DTOs;

namespace Bunker.Api.Controllers;

public class BunkerOrderController : ApiControllerBase
{
    private readonly CreateBunkerOrderHandler _createHandler;
    private readonly GetAllBunkerOrdersHandler _getAllHandler;
    private readonly GetBunkerOrderByIdHandler _getByIdHandler;
    private readonly UpdateBunkerOrderHandler _updateHandler;
    private readonly DeleteBunkerOrderHandler _deleteHandler;

    public BunkerOrderController(
        CreateBunkerOrderHandler createHandler,
        GetAllBunkerOrdersHandler getAllHandler,
        GetBunkerOrderByIdHandler getByIdHandler,
        UpdateBunkerOrderHandler updateHandler,
        DeleteBunkerOrderHandler deleteHandler)
    {
        _createHandler = createHandler;
        _getAllHandler = getAllHandler;
        _getByIdHandler = getByIdHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
    }

    /// <summary>
    /// Create a new bunker order
    /// </summary>
    /// <param name="request">The bunker order creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created bunker order response</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateBunkerOrder(
        [FromBody] CreateBunkerOrderCommand request,
        CancellationToken cancellationToken = default)
    {
        var result = await _createHandler.Handle(request, cancellationToken);
        return HandleCommandResult(result);
    }

    /// <summary>
    /// Get all bunker orders with optional filtering and pagination
    /// </summary>
    /// <param name="request">The query parameters</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of bunker orders</returns>
    [HttpGet]
    [ProducesResponseType(typeof(GetAllBunkerOrdersResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(QueryApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllBunkerOrders(
        [FromQuery] GetAllBunkerOrdersQuery request,
        CancellationToken cancellationToken = default)
    {
        var result = await _getAllHandler.Handle(request, cancellationToken);
        return HandleQueryResult(result);
    }

    /// <summary>
    /// Get a bunker order by ID
    /// </summary>
    /// <param name="id">The bunker order ID</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The bunker order details</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetBunkerOrderByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(QueryApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(QueryApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetBunkerOrderById(
        int id,
        CancellationToken cancellationToken = default)
    {
        var request = new GetBunkerOrderByIdQuery { Id = id };
        var result = await _getByIdHandler.Handle(request, cancellationToken);
        return HandleQueryResult(result);
    }

    /// <summary>
    /// Update an existing bunker order
    /// </summary>
    /// <param name="id">The bunker order ID</param>
    /// <param name="request">The update request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated bunker order response</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateBunkerOrder(
        int id,
        [FromBody] UpdateBunkerOrderCommand request,
        CancellationToken cancellationToken = default)
    {
        request.BunkerOrder.Id = id;
        var result = await _updateHandler.Handle(request, cancellationToken);
        return HandleCommandResult(result);
    }

    /// <summary>
    /// Delete a bunker order
    /// </summary>
    /// <param name="id">The bunker order ID</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteBunkerOrder(
        int id,
        CancellationToken cancellationToken = default)
    {
        var request = new DeleteBunkerOrderCommand { Id = id };
        var result = await _deleteHandler.Handle(request, cancellationToken);
        return HandleCommandResult(result);
    }
}
