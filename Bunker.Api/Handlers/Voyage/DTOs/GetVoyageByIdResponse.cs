using Bunker.Api.Handlers._Shared;

namespace Bunker.Api.Handlers.Voyage.DTOs;

public class GetVoyageByIdResponse : QueryApiResponse<GetVoyageByIdResponse>
{
    public VoyageResponseDto Voyage { get; set; } = new();
}
