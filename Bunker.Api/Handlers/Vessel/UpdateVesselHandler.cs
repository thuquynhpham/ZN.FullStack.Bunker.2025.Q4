using Bunker.Api.Handlers._Shared;
using Bunker.Api.Handlers.Vessel.DTOs;
using Bunker.Domain.Repositories;

namespace Bunker.Api.Handlers.Vessel;

public class UpdateVesselHandler : CommandHandlerBase<UpdateVesselCommand>
{
    private readonly IVesselRepository _vesselRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVesselHandler(IUnitOfWork unitOfWork)
    {
        _vesselRepository = unitOfWork.Vessels;
        _unitOfWork = unitOfWork;
    }

    public override async Task<CommandApiResponse> Handle(UpdateVesselCommand request, CancellationToken ct)
    {
        try
        {
            var existingVessel = await _vesselRepository.GetByIdAsync(request.Vessel.Id, ct);
            if (existingVessel == null)
            {
                return CommandApiResponse.CreateNotFound($"Vessel with ID {request.Vessel.Id} not found");
            }

            // Check for duplicate IMO (excluding current vessel)
            var existingVesselWithIMO = await _vesselRepository.GetAllAsync(ct);
            if (existingVesselWithIMO.Any(v => v.IMO == request.Vessel.IMO && v.Id != request.Vessel.Id))
            {
                return CommandApiResponse.CreateValidationFailed("IMO number already exists");
            }

            // Check for duplicate MMSI if provided (excluding current vessel)
            if (!string.IsNullOrEmpty(request.Vessel.MMSI))
            {
                if (existingVesselWithIMO.Any(v => v.MMSI == request.Vessel.MMSI && v.Id != request.Vessel.Id))
                {
                    return CommandApiResponse.CreateValidationFailed("MMSI number already exists");
                }
            }

            // Check for duplicate CallSign if provided (excluding current vessel)
            if (!string.IsNullOrEmpty(request.Vessel.CallSign))
            {
                if (existingVesselWithIMO.Any(v => v.CallSign == request.Vessel.CallSign && v.Id != request.Vessel.Id))
                {
                    return CommandApiResponse.CreateValidationFailed("Call sign already exists");
                }
            }

            // Update vessel properties
            existingVessel.Name = request.Vessel.Name;
            existingVessel.IMO = request.Vessel.IMO;
            existingVessel.MMSI = request.Vessel.MMSI;
            existingVessel.CallSign = request.Vessel.CallSign;
            existingVessel.VesselType = request.Vessel.VesselType;
            existingVessel.Flag = request.Vessel.Flag;
            existingVessel.Status = request.Vessel.Status;
            existingVessel.YearBuilt = request.Vessel.YearBuilt;
            existingVessel.Length = request.Vessel.Length;
            existingVessel.Width = request.Vessel.Width;
            existingVessel.Draft = request.Vessel.Draft;
            existingVessel.GrossTonnage = request.Vessel.GrossTonnage;
            existingVessel.NetTonnage = request.Vessel.NetTonnage;
            existingVessel.Deadweight = request.Vessel.Deadweight;
            existingVessel.UpdatedBy = request.Vessel.UpdatedBy;
            existingVessel.Notes = request.Vessel.Notes;
            existingVessel.UpdatedAt = DateTime.UtcNow;

            await _vesselRepository.UpdateAsync(existingVessel, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return CommandApiResponse.Success($"Vessel {existingVessel.Name} updated successfully");
        }
        catch (Exception ex)
        {
            return CommandApiResponse.CreateServerError($"An error occurred while updating vessel: {ex.Message}");
        }
    }
}

public class UpdateVesselCommand : ICommand
{
    public UpdateVesselDto Vessel { get; set; } = new();
}
