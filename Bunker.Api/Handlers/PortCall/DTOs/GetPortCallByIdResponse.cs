using Bunker.Api.Handlers._Shared;

namespace Bunker.Api.Handlers.PortCall.DTOs;

public class GetPortCallByIdResponse : QueryApiResponse<GetPortCallByIdResponse>
{
    public PortCallResponseDto PortCall { get; set; } = new();
}
