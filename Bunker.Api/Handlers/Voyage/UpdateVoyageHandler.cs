using Bunker.Api.Handlers._Shared;
using Bunker.Api.Handlers.Voyage.DTOs;
using Bunker.Domain.Repositories;

namespace Bunker.Api.Handlers.Voyage;

public class UpdateVoyageHandler(IUnitOfWork unitOfWork) : CommandHandlerBase<UpdateVoyageCommand>
{
    private readonly IVoyageRepository _voyageRepository = unitOfWork.Voyages;
    private readonly IVesselRepository _vesselRepository = unitOfWork.Vessels;
    private readonly IPortRepository _portRepository = unitOfWork.Ports;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public override async Task<CommandApiResponse> Handle(UpdateVoyageCommand request, CancellationToken ct)
    {
        try
        {
            var existingVoyage = await _voyageRepository.GetByIdAsync(request.Voyage.Id, ct);
            if (existingVoyage == null)
            {
                return CommandApiResponse.CreateNotFound($"Voyage with ID {request.Voyage.Id} not found");
            }

            // Validate that Vessel exists
            var vessel = await _vesselRepository.GetByIdAsync(request.Voyage.VesselId, ct);
            if (vessel == null)
            {
                return CommandApiResponse.CreateValidationFailed("Vessel not found");
            }

            // Validate DeparturePort if provided
            if (request.Voyage.DeparturePortId.HasValue)
            {
                var departurePort = await _portRepository.GetByIdAsync(request.Voyage.DeparturePortId.Value, ct);
                if (departurePort == null)
                {
                    return CommandApiResponse.CreateValidationFailed("Departure port not found");
                }
            }

            // Validate ArrivalPort if provided
            if (request.Voyage.ArrivalPortId.HasValue)
            {
                var arrivalPort = await _portRepository.GetByIdAsync(request.Voyage.ArrivalPortId.Value, ct);
                if (arrivalPort == null)
                {
                    return CommandApiResponse.CreateValidationFailed("Arrival port not found");
                }
            }

            // Check for duplicate voyage number (excluding current voyage)
            var existingVoyageWithNumber = await _voyageRepository.GetAllAsync(ct);
            if (existingVoyageWithNumber.Any(v => v.VoyageNumber == request.Voyage.VoyageNumber && v.Id != request.Voyage.Id))
            {
                return CommandApiResponse.CreateValidationFailed("Voyage number already exists");
            }

            // Update voyage properties
            existingVoyage.VesselId = request.Voyage.VesselId;
            existingVoyage.DeparturePortId = request.Voyage.DeparturePortId;
            existingVoyage.ArrivalPortId = request.Voyage.ArrivalPortId;
            existingVoyage.VoyageNumber = request.Voyage.VoyageNumber;
            existingVoyage.ScheduledDeparture = request.Voyage.ScheduledDeparture;
            existingVoyage.ActualDeparture = request.Voyage.ActualDeparture;
            existingVoyage.ScheduledArrival = request.Voyage.ScheduledArrival;
            existingVoyage.ActualArrival = request.Voyage.ActualArrival;
            existingVoyage.Status = request.Voyage.Status;
            existingVoyage.UpdatedBy = request.Voyage.UpdatedBy;
            existingVoyage.Notes = request.Voyage.Notes;
            existingVoyage.UpdatedAt = DateTime.UtcNow;

            await _voyageRepository.UpdateAsync(existingVoyage, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return CommandApiResponse.Success($"Voyage {existingVoyage.VoyageNumber} updated successfully");
        }
        catch (Exception ex)
        {
            return CommandApiResponse.CreateServerError($"An error occurred while updating voyage: {ex.Message}");
        }
    }
}

public class UpdateVoyageCommand : ICommand
{
    public UpdateVoyageDto Voyage { get; set; } = new();
}
