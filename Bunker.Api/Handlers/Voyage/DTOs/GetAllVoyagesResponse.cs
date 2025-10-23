using Bunker.Api.Handlers._Shared;

namespace Bunker.Api.Handlers.Voyage.DTOs;

public class GetAllVoyagesResponse : QueryApiResponse<GetAllVoyagesResponse>
{
    public List<VoyageResponseDto> Voyages { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
}
