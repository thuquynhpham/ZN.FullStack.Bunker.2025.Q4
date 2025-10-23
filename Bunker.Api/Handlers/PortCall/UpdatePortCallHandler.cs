using Bunker.Api.Handlers._Shared;
using Bunker.Api.Handlers.PortCall.DTOs;
using Bunker.Domain.Repositories;

namespace Bunker.Api.Handlers.PortCall;

public class UpdatePortCallHandler(IUnitOfWork unitOfWork) : CommandHandlerBase<UpdatePortCallCommand>
{
    private readonly IPortCallRepository _portCallRepository = unitOfWork.PortCalls;
    private readonly IVesselRepository _vesselRepository = unitOfWork.Vessels;
    private readonly IPortRepository _portRepository = unitOfWork.Ports;
    private readonly IVoyageRepository _voyageRepository = unitOfWork.Voyages;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public override async Task<CommandApiResponse> Handle(UpdatePortCallCommand request, CancellationToken ct)
    {
        try
        {
            var existingPortCall = await _portCallRepository.GetByIdAsync(request.PortCall.Id, ct);
            if (existingPortCall == null)
            {
                return CommandApiResponse.CreateNotFound($"Port call with ID {request.PortCall.Id} not found");
            }

            // Validate that Vessel exists
            var vessel = await _vesselRepository.GetByIdAsync(request.PortCall.VesselId, ct);
            if (vessel == null)
            {
                return CommandApiResponse.CreateValidationFailed("Vessel not found");
            }

            // Validate that Port exists
            var port = await _portRepository.GetByIdAsync(request.PortCall.PortId, ct);
            if (port == null)
            {
                return CommandApiResponse.CreateValidationFailed("Port not found");
            }

            // Validate Voyage if provided
            if (request.PortCall.VoyageId.HasValue)
            {
                var voyage = await _voyageRepository.GetByIdAsync(request.PortCall.VoyageId.Value, ct);
                if (voyage == null)
                {
                    return CommandApiResponse.CreateValidationFailed("Voyage not found");
                }
            }

            // Update port call properties
            existingPortCall.VesselId = request.PortCall.VesselId;
            existingPortCall.PortId = request.PortCall.PortId;
            existingPortCall.VoyageId = request.PortCall.VoyageId;
            existingPortCall.CallType = request.PortCall.CallType;
            existingPortCall.ScheduledArrival = request.PortCall.ScheduledArrival;
            existingPortCall.ActualArrival = request.PortCall.ActualArrival;
            existingPortCall.ScheduledDeparture = request.PortCall.ScheduledDeparture;
            existingPortCall.ActualDeparture = request.PortCall.ActualDeparture;
            existingPortCall.Status = request.PortCall.Status;
            existingPortCall.UpdatedBy = request.PortCall.UpdatedBy;
            existingPortCall.Notes = request.PortCall.Notes;
            existingPortCall.UpdatedAt = DateTime.UtcNow;

            await _portCallRepository.UpdateAsync(existingPortCall, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return CommandApiResponse.Success();
        }
        catch (Exception ex)
        {
            return CommandApiResponse.CreateServerError($"An error occurred while updating port call: {ex.Message}");
        }
    }
}

public class UpdatePortCallCommand : ICommand
{
    public UpdatePortCallDto PortCall { get; }

    public UpdatePortCallCommand(UpdatePortCallDto portCall)
    {
        PortCall = portCall;
    }
}
