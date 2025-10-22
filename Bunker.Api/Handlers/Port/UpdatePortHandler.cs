using Bunker.Api.Handlers._Shared;
using Bunker.Api.Handlers.Port.DTOs;
using Bunker.Domain.Repositories;

namespace Bunker.Api.Handlers.Port;

public class UpdatePortHandler : CommandHandlerBase<UpdatePortCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPortRepository _portRepository;

    public UpdatePortHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _portRepository = _unitOfWork.Ports;
    }

    public override async Task<CommandApiResponse> Handle(UpdatePortCommand command, CancellationToken ct)
    {
        try
        {
            var existingPort = await _portRepository.GetByIdAsync(command.Port.Id, ct);
            if (existingPort == null)
            {
                return CommandApiResponse.CreateNotFound($"Port with ID {command.Port.Id} not found");
            }

            // Check if UNLOCODE already exists (excluding current port)
            var existingPorts = await _portRepository.GetAllAsync(ct);
            if (existingPorts.Any(p => p.UNLOCODE == command.Port.UNLOCODE && p.Id != command.Port.Id))
            {
                return CommandApiResponse.CreateValidationFailed($"Port with UNLOCODE '{command.Port.UNLOCODE}' already exists");
            }

            // Update the port
            existingPort.UNLOCODE = command.Port.UNLOCODE;
            existingPort.Name = command.Port.Name;
            existingPort.AlternativeName = command.Port.AlternativeName;
            existingPort.Country = command.Port.Country;
            existingPort.City = command.Port.City;
            existingPort.State = command.Port.State;
            existingPort.Latitude = command.Port.Latitude;
            existingPort.Longitude = command.Port.Longitude;
            existingPort.TimeZone = command.Port.TimeZone;
            existingPort.PortType = command.Port.PortType;
            existingPort.Size = command.Port.Size;
            existingPort.MaxDraft = command.Port.MaxDraft;
            existingPort.MaxVesselLength = command.Port.MaxVesselLength;
            existingPort.MaxVesselBeam = command.Port.MaxVesselBeam;
            existingPort.MaxDWT = command.Port.MaxDWT;
            existingPort.NumberOfBerths = command.Port.NumberOfBerths;
            existingPort.NumberOfTerminals = command.Port.NumberOfTerminals;
            existingPort.HasContainerFacilities = command.Port.HasContainerFacilities;
            existingPort.HasBulkFacilities = command.Port.HasBulkFacilities;
            existingPort.HasLiquidFacilities = command.Port.HasLiquidFacilities;
            existingPort.HasRoRoFacilities = command.Port.HasRoRoFacilities;
            existingPort.HasPassengerFacilities = command.Port.HasPassengerFacilities;
            existingPort.HasBunkeringFacilities = command.Port.HasBunkeringFacilities;
            existingPort.HasRepairFacilities = command.Port.HasRepairFacilities;
            existingPort.Is24Hours = command.Port.Is24Hours;
            existingPort.IsIceFree = command.Port.IsIceFree;
            existingPort.Status = command.Port.Status;
            existingPort.PortAuthority = command.Port.PortAuthority;
            existingPort.ContactPhone = command.Port.ContactPhone;
            existingPort.ContactEmail = command.Port.ContactEmail;
            existingPort.Website = command.Port.Website;
            existingPort.AverageWaitingTimeHours = command.Port.AverageWaitingTimeHours;
            existingPort.AverageTurnaroundTimeHours = command.Port.AverageTurnaroundTimeHours;
            existingPort.AnnualCargoThroughputTEU = command.Port.AnnualCargoThroughputTEU;
            existingPort.AnnualVesselCalls = command.Port.AnnualVesselCalls;
            existingPort.UpdatedAt = DateTime.UtcNow;
            existingPort.UpdatedBy = command.Port.UpdatedBy;
            existingPort.Notes = command.Port.Notes;

            await _portRepository.UpdateAsync(existingPort, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return CommandApiResponse.Success(existingPort.Id);
        }
        catch (Exception ex)
        {
            return CommandApiResponse.CreateServerError($"An error occurred while updating the port: {ex.Message}");
        }
    }
}

public class UpdatePortCommand : ICommand
{
    public UpdatePortDto Port { get; set; } = new();
}
