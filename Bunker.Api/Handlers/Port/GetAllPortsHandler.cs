using Bunker.Api.Handlers._Shared;
using Bunker.Api.Handlers.Port.DTOs;
using Bunker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bunker.Api.Handlers.Port;

public class GetAllPortsHandler : QueryHandlerBase<GetAllPortsQuery, GetAllPortsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPortRepository _portRepository;

    public GetAllPortsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _portRepository = unitOfWork.Ports;
    }

    public override async Task<GetAllPortsResponse> Handle(GetAllPortsQuery request, CancellationToken ct)
    {
        try
        {
            var query = _portRepository.GetAll();

            // Apply filters
            if (!string.IsNullOrEmpty(request.Country))
            {
                query = query.Where(p => p.Country == request.Country);
            }

            if (!string.IsNullOrEmpty(request.PortType))
            {
                query = query.Where(p => p.PortType == request.PortType);
            }

            if (!string.IsNullOrEmpty(request.Size))
            {
                query = query.Where(p => p.Size == request.Size);
            }

            if (!string.IsNullOrEmpty(request.Status))
            {
                query = query.Where(p => p.Status == request.Status);
            }

            if (request.HasBunkeringFacilities.HasValue)
            {
                query = query.Where(p => p.HasBunkeringFacilities == request.HasBunkeringFacilities.Value);
            }

            if (request.HasContainerFacilities.HasValue)
            {
                query = query.Where(p => p.HasContainerFacilities == request.HasContainerFacilities.Value);
            }

            if (request.HasBulkFacilities.HasValue)
            {
                query = query.Where(p => p.HasBulkFacilities == request.HasBulkFacilities.Value);
            }

            if (request.HasLiquidFacilities.HasValue)
            {
                query = query.Where(p => p.HasLiquidFacilities == request.HasLiquidFacilities.Value);
            }

            // Get total count
            var totalCount = await query.CountAsync(ct);

            // Apply pagination
            var ports = await query
                .OrderBy(p => p.Name)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(ct);

            var portDtos = ports.Select(PortResponseDto.Create).ToList();

            var totalPages = (int)Math.Ceiling((double)totalCount / request.PageSize);

            var response = new GetAllPortsResponse
            {
                Ports = portDtos,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalPages = totalPages
            };

            return response;
        }
        catch (Exception ex)
        {
            return GetAllPortsResponse.CreateServerError($"An error occurred while retrieving ports: {ex.Message}");
        }
    }
}

public record GetAllPortsQuery : IQuery<GetAllPortsResponse>
{
    public string? Country { get; set; }
    public string? PortType { get; set; }
    public string? Size { get; set; }
    public string? Status { get; set; }
    public bool? HasBunkeringFacilities { get; set; }
    public bool? HasContainerFacilities { get; set; }
    public bool? HasBulkFacilities { get; set; }
    public bool? HasLiquidFacilities { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetAllPortsResponse : QueryApiResponse<GetAllPortsResponse>
{
    public List<PortResponseDto> Ports { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
}
