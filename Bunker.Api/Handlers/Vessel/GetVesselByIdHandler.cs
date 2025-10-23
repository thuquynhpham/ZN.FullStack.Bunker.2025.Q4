using Bunker.Api.Handlers._Shared;
using Bunker.Api.Handlers.Vessel.DTOs;
using Bunker.Domain.Repositories;

namespace Bunker.Api.Handlers.Vessel;

public class GetVesselByIdHandler(IUnitOfWork unitOfWork) : QueryHandlerBase<GetVesselByIdQuery, GetVesselByIdResponse>
{
    private readonly IVesselRepository _vesselRepository = unitOfWork.Vessels;

    public override async Task<GetVesselByIdResponse> Handle(GetVesselByIdQuery request, CancellationToken ct)
    {
        try
        {
            var vessel = await _vesselRepository.GetByIdAsync(request.Id, ct);

            if (vessel == null)
            {
                return QueryApiResponse<GetVesselByIdResponse>.CreateNotFound($"Vessel with ID {request.Id} not found");
            }

            var vesselDto = VesselResponseDto.Create(vessel);

            return QueryApiResponse<GetVesselByIdResponse>.Success(new GetVesselByIdResponse
            {
                Vessel = vesselDto
            });
        }
        catch (Exception ex)
        {
            return QueryApiResponse<GetVesselByIdResponse>.CreateServerError($"An error occurred while retrieving vessel: {ex.Message}");
        }
    }
}

public class GetVesselByIdQuery : IQuery<GetVesselByIdResponse>
{
    public int Id { get; set; }
}
