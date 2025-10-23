using Bunker.Api.Handlers._Shared;
using Bunker.Api.Handlers.PortCall.DTOs;
using Bunker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bunker.Api.Handlers.PortCall;

public class GetAllPortCallsHandler(IUnitOfWork unitOfWork) : QueryHandlerBase<GetAllPortCallsQuery, GetAllPortCallsResponse>
{
    private readonly IPortCallRepository _portCallRepository = unitOfWork.PortCalls;

    public override async Task<GetAllPortCallsResponse> Handle(GetAllPortCallsQuery request, CancellationToken ct)
    {
        try
        {
            var portCalls = await _portCallRepository.GetAllAsync(
                query => query
                    .Include(pc => pc.Vessel)
                    .Include(pc => pc.Port)
                    .Include(pc => pc.Voyage)
                    .AsSplitQuery()
                    .AsNoTracking(),
                ct);

            var query = portCalls.AsQueryable();

            // Apply filters
            if (request.VesselId.HasValue)
            {
                query = query.Where(pc => pc.VesselId == request.VesselId.Value);
            }

            if (request.PortId.HasValue)
            {
                query = query.Where(pc => pc.PortId == request.PortId.Value);
            }

            if (request.VoyageId.HasValue)
            {
                query = query.Where(pc => pc.VoyageId == request.VoyageId.Value);
            }

            if (!string.IsNullOrEmpty(request.CallType))
            {
                query = query.Where(pc => pc.CallType == request.CallType);
            }

            if (request.ArrivalDateFrom.HasValue)
            {
                query = query.Where(pc => pc.ScheduledArrival >= request.ArrivalDateFrom.Value);
            }

            if (request.ArrivalDateTo.HasValue)
            {
                query = query.Where(pc => pc.ScheduledArrival <= request.ArrivalDateTo.Value);
            }

            if (request.DepartureDateFrom.HasValue)
            {
                query = query.Where(pc => pc.ScheduledDeparture >= request.DepartureDateFrom.Value);
            }

            if (request.DepartureDateTo.HasValue)
            {
                query = query.Where(pc => pc.ScheduledDeparture <= request.DepartureDateTo.Value);
            }

            if (!string.IsNullOrEmpty(request.Status))
            {
                query = query.Where(pc => pc.Status == request.Status);
            }

            var totalCount = query.Count();

            // Apply pagination
            var portCallsPagination = await query
                .OrderByDescending(pc => pc.CreatedAt)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(ct);

            var portCallDtos = portCallsPagination.Select(PortCallResponseDto.Create).ToList();

            var totalPages = (int)Math.Ceiling((double)totalCount / request.PageSize);

            return QueryApiResponse<GetAllPortCallsResponse>.Success(new GetAllPortCallsResponse
            {
                PortCalls = portCallDtos,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalPages = totalPages
            });
        }
        catch (Exception ex)
        {
            return QueryApiResponse<GetAllPortCallsResponse>.CreateServerError($"An error occurred while retrieving port calls: {ex.Message}");
        }
    }
}

public record GetAllPortCallsQuery : IQuery<GetAllPortCallsResponse>
{
    public int? VesselId { get; set; }
    public int? PortId { get; set; }
    public int? VoyageId { get; set; }
    public string? CallType { get; set; }
    public DateTime? ArrivalDateFrom { get; set; }
    public DateTime? ArrivalDateTo { get; set; }
    public DateTime? DepartureDateFrom { get; set; }
    public DateTime? DepartureDateTo { get; set; }
    public string? Status { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
