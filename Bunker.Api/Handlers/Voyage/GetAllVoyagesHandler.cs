using Bunker.Api.Handlers._Shared;
using Bunker.Api.Handlers.Voyage.DTOs;
using Bunker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bunker.Api.Handlers.Voyage;

public class GetAllVoyagesHandler(IUnitOfWork unitOfWork) : QueryHandlerBase<GetAllVoyagesQuery, GetAllVoyagesResponse>
{
    private readonly IVoyageRepository _voyageRepository = unitOfWork.Voyages;

    public override async Task<GetAllVoyagesResponse> Handle(GetAllVoyagesQuery request, CancellationToken ct)
    {
        try
        {
            var voyages = await _voyageRepository.GetAllAsync(
                query => query
                    .Include(v => v.Vessel)
                    .Include(v => v.DeparturePort)
                    .Include(v => v.ArrivalPort),
                ct);

            var query = voyages.AsQueryable();

            // Apply filters
            if (request.VesselId.HasValue)
            {
                query = query.Where(v => v.VesselId == request.VesselId.Value);
            }

            if (request.DeparturePortId.HasValue)
            {
                query = query.Where(v => v.DeparturePortId == request.DeparturePortId.Value);
            }

            if (request.ArrivalPortId.HasValue)
            {
                query = query.Where(v => v.ArrivalPortId == request.ArrivalPortId.Value);
            }

            if (!string.IsNullOrEmpty(request.VoyageNumber))
            {
                query = query.Where(v => v.VoyageNumber.Contains(request.VoyageNumber));
            }

            if (request.DepartureDateFrom.HasValue)
            {
                query = query.Where(v => v.ScheduledDeparture >= request.DepartureDateFrom.Value);
            }

            if (request.DepartureDateTo.HasValue)
            {
                query = query.Where(v => v.ScheduledDeparture <= request.DepartureDateTo.Value);
            }

            if (request.ArrivalDateFrom.HasValue)
            {
                query = query.Where(v => v.ScheduledArrival >= request.ArrivalDateFrom.Value);
            }

            if (request.ArrivalDateTo.HasValue)
            {
                query = query.Where(v => v.ScheduledArrival <= request.ArrivalDateTo.Value);
            }

            if (!string.IsNullOrEmpty(request.Status))
            {
                query = query.Where(v => v.Status == request.Status);
            }

            var totalCount = query.Count();

            // Apply pagination
            var voyagesPagination = await query
                .OrderByDescending(v => v.CreatedAt)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(ct);

            var voyageDtos = voyagesPagination.Select(VoyageResponseDto.Create).ToList();

            var totalPages = (int)Math.Ceiling((double)totalCount / request.PageSize);

            return QueryApiResponse<GetAllVoyagesResponse>.Success(new GetAllVoyagesResponse
            {
                Voyages = voyageDtos,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalPages = totalPages
            });
        }
        catch (Exception ex)
        {
            return QueryApiResponse<GetAllVoyagesResponse>.CreateServerError($"An error occurred while retrieving voyages: {ex.Message}");
        }
    }
}

public class GetAllVoyagesQuery : IQuery<GetAllVoyagesResponse>
{
    public int? VesselId { get; set; }
    public int? DeparturePortId { get; set; }
    public int? ArrivalPortId { get; set; }
    public string? VoyageNumber { get; set; }
    public DateTime? DepartureDateFrom { get; set; }
    public DateTime? DepartureDateTo { get; set; }
    public DateTime? ArrivalDateFrom { get; set; }
    public DateTime? ArrivalDateTo { get; set; }
    public string? Status { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
