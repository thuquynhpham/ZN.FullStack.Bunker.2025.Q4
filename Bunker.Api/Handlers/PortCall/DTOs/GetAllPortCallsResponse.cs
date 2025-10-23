using Bunker.Api.Handlers._Shared;

namespace Bunker.Api.Handlers.PortCall.DTOs;

public class GetAllPortCallsResponse : QueryApiResponse<GetAllPortCallsResponse>
{
    public List<PortCallResponseDto> PortCalls { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
}
