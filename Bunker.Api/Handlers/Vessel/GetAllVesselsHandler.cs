using Bunker.Api.Handlers._Shared;
using Bunker.Api.Handlers.Vessel.DTOs;
using Bunker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bunker.Api.Handlers.Vessel;

public class GetAllVesselsHandler(IUnitOfWork unitOfWork) : QueryHandlerBase<GetAllVesselsQuery, GetAllVesselsResponse>
{
    private readonly IVesselRepository _vesselRepository = unitOfWork.Vessels;

    public override async Task<GetAllVesselsResponse> Handle(GetAllVesselsQuery request, CancellationToken ct)
    {
        try
        {
            var vesselQuery = _vesselRepository.GetAll();
            
            var totalCount = vesselQuery.Count();

            // Apply pagination
            var vesselsPagination = await vesselQuery
                .OrderBy(v => v.Name)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(ct);

            var vesselDtos = vesselsPagination.Select(VesselResponseDto.Create).ToList();

            var totalPages = (int)Math.Ceiling((double)totalCount / request.PageSize);

            return QueryApiResponse<GetAllVesselsResponse>.Success(new GetAllVesselsResponse
            {
                Vessels = vesselDtos,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalPages = totalPages
            });
        }
        catch (Exception ex)
        {
            return QueryApiResponse<GetAllVesselsResponse>.CreateServerError($"An error occurred while retrieving vessels: {ex.Message}");
        }
    }
}

public class GetAllVesselsQuery : IQuery<GetAllVesselsResponse>
{
    public string? Name { get; set; }
    public string? IMO { get; set; }
    public string? MMSI { get; set; }
    public string? CallSign { get; set; }
    public string? VesselType { get; set; }
    public string? Flag { get; set; }
    public string? Status { get; set; }
    public int? YearBuilt { get; set; }
    public int? YearBuiltFrom { get; set; }
    public int? YearBuiltTo { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
