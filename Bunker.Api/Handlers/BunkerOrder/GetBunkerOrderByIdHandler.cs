using Bunker.Api.Handlers._Shared;
using Bunker.Api.Handlers.BunkerOrder.DTOs;
using Bunker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bunker.Api.Handlers.BunkerOrder;

public class GetBunkerOrderByIdHandler : QueryHandlerBase<GetBunkerOrderByIdQuery, GetBunkerOrderByIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBunkerOrderRepository _bunkerOrderRepository;

    public GetBunkerOrderByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _bunkerOrderRepository = _unitOfWork.BunkerOrders;
    }

    public override async Task<GetBunkerOrderByIdResponse> Handle(GetBunkerOrderByIdQuery request, CancellationToken ct)
    {
        try
        {
            var bunkerOrders = await _bunkerOrderRepository.GetAllAsync(
                query => query
                    .Include(bo => bo.Vessel)
                    .Include(bo => bo.Port)
                    .Include(bo => bo.Voyage)
                    .Include(bo => bo.PortCall),
                ct);

            var bunkerOrder = bunkerOrders.FirstOrDefault(bo => bo.Id == request.Id);

            if (bunkerOrder == null)
            {
                return GetBunkerOrderByIdResponse.CreateNotFound($"Bunker order with ID {request.Id} not found");
            }

            var response = new GetBunkerOrderByIdResponse
            {
                BunkerOrder = BunkerOrderResponseDto.Create(bunkerOrder)
            };

            return response;
        }
        catch (Exception ex)
        {
            return GetBunkerOrderByIdResponse.CreateServerError($"An error occurred while retrieving the bunker order: {ex.Message}");
        }
    }
}

public class GetBunkerOrderByIdQuery : IQuery<GetBunkerOrderByIdResponse>
{
    public int Id { get; set; }
}

public class GetBunkerOrderByIdResponse : QueryApiResponse<GetBunkerOrderByIdResponse>
{
    public BunkerOrderResponseDto? BunkerOrder { get; set; }
}
