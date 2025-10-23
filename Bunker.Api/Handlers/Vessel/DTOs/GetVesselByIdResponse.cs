using Bunker.Api.Handlers._Shared;

namespace Bunker.Api.Handlers.Vessel.DTOs;

public class GetVesselByIdResponse : QueryApiResponse<GetVesselByIdResponse>
{
    public VesselResponseDto Vessel { get; set; } = new();
}
