using Bunker.Api.Handlers._Shared;
using Bunker.Api.Handlers.Voyage.DTOs;
using Bunker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bunker.Api.Handlers.Voyage;

public class GetVoyageByIdHandler(IUnitOfWork unitOfWork) : QueryHandlerBase<GetVoyageByIdQuery, GetVoyageByIdResponse>
{
    private readonly IVoyageRepository _voyageRepository = unitOfWork.Voyages;

    public override async Task<GetVoyageByIdResponse> Handle(GetVoyageByIdQuery request, CancellationToken ct)
    {
        try
        {
            var voyages = await _voyageRepository.GetAllAsync(
                query => query
                    .Include(v => v.Vessel)
                    .Include(v => v.DeparturePort)
                    .Include(v => v.ArrivalPort),
                ct);

            var voyage = voyages.FirstOrDefault(v => v.Id == request.Id);

            if (voyage == null)
            {
                return QueryApiResponse<GetVoyageByIdResponse>.CreateNotFound($"Voyage with ID {request.Id} not found");
            }

            var voyageDto = VoyageResponseDto.Create(voyage);

            return QueryApiResponse<GetVoyageByIdResponse>.Success(new GetVoyageByIdResponse
            {
                Voyage = voyageDto
            });
        }
        catch (Exception ex)
        {
            return QueryApiResponse<GetVoyageByIdResponse>.CreateServerError($"An error occurred while retrieving voyage: {ex.Message}");
        }
    }
}

public class GetVoyageByIdQuery : IQuery<GetVoyageByIdResponse>
{
    public int Id { get; set; }
}
