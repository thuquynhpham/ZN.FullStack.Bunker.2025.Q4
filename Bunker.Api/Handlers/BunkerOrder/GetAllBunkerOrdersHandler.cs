using Bunker.Api.Handlers._Shared;
using Bunker.Api.Handlers.BunkerOrder.DTOs;
using Bunker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bunker.Api.Handlers.BunkerOrder;

public class GetAllBunkerOrdersHandler : QueryHandlerBase<GetAllBunkerOrdersQuery, GetAllBunkerOrdersResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBunkerOrderRepository _bunkerOrderRepository;

    public GetAllBunkerOrdersHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _bunkerOrderRepository = _unitOfWork.BunkerOrders;
    }

    public override async Task<GetAllBunkerOrdersResponse> Handle(GetAllBunkerOrdersQuery request, CancellationToken ct)
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

            var query = bunkerOrders.AsQueryable();

            // Apply filters
            if (request.VesselId.HasValue)
            {
                query = query.Where(bo => bo.VesselId == request.VesselId.Value);
            }

            if (request.PortId.HasValue)
            {
                query = query.Where(bo => bo.PortId == request.PortId.Value);
            }

            if (request.VoyageId.HasValue)
            {
                query = query.Where(bo => bo.VoyageId == request.VoyageId.Value);
            }

            if (!string.IsNullOrEmpty(request.Status))
            {
                query = query.Where(bo => bo.Status == request.Status);
            }

            if (!string.IsNullOrEmpty(request.FuelType))
            {
                query = query.Where(bo => bo.FuelType == request.FuelType);
            }

            if (request.FromDate.HasValue)
            {
                query = query.Where(bo => bo.CreatedAt >= request.FromDate.Value);
            }

            if (request.ToDate.HasValue)
            {
                query = query.Where(bo => bo.CreatedAt <= request.ToDate.Value);
            }

            // Get total count
            var totalCount = await query.CountAsync(ct);

            // Apply pagination
            var bunkerOrdersPagination = await query
                .OrderByDescending(bo => bo.CreatedAt)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(ct);

            var bunkerOrderDtos = bunkerOrdersPagination.Select(BunkerOrderResponseDto.Create).ToList();

            var totalPages = (int)Math.Ceiling((double)totalCount / request.PageSize);

            var response = new GetAllBunkerOrdersResponse
            {
                BunkerOrders = bunkerOrderDtos,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalPages = totalPages
            };

            return response;
        }
        catch (Exception ex)
        {
            return GetAllBunkerOrdersResponse.CreateServerError($"An error occurred while retrieving bunker orders: {ex.Message}");
        }
    }
}

public class GetAllBunkerOrdersQuery : IQuery<GetAllBunkerOrdersResponse>
{
    public int? VesselId { get; set; }
    public int? PortId { get; set; }
    public int? VoyageId { get; set; }
    public string? Status { get; set; }
    public string? FuelType { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetAllBunkerOrdersResponse : QueryApiResponse<GetAllBunkerOrdersResponse>
{
    public List<BunkerOrderResponseDto> BunkerOrders { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
}
