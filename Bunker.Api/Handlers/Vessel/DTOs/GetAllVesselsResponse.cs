using Bunker.Api.Handlers._Shared;

namespace Bunker.Api.Handlers.Vessel.DTOs;

public class GetAllVesselsResponse : QueryApiResponse<GetAllVesselsResponse>
{
    public List<VesselResponseDto> Vessels { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
}
