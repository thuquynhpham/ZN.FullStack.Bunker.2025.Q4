using Bunker.Api.Handlers._Shared;
using Bunker.Api.Handlers.PortCall.DTOs;
using Bunker.Domain.Models;
using Bunker.Domain.Repositories;

namespace Bunker.Api.Handlers.PortCall;

public class CreatePortCallHandler : CommandHandlerBase<CreatePortCallCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IVesselRepository _vesselRepository;
    private readonly IPortRepository _portRepository;
    private readonly IVoyageRepository _voyageRepository;
    private readonly IPortCallRepository _portCallRepository;

    public CreatePortCallHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _vesselRepository = _unitOfWork.Vessels;
        _portRepository = _unitOfWork.Ports;
        _voyageRepository = _unitOfWork.Voyages;
        _portCallRepository = _unitOfWork.PortCalls;
    }

    public override async Task<CommandApiResponse> Handle(CreatePortCallCommand command, CancellationToken ct)
    {
        try
        {
            // Validate that Vessel exists
            var vessel = await _vesselRepository.GetByIdAsync(command.PortCall.VesselId, ct);
            if (vessel == null)
            {
                return CommandApiResponse.CreateNotFound($"Vessel with ID {command.PortCall.VesselId} not found");
            }

            // Validate that Port exists
            var port = await _portRepository.GetByIdAsync(command.PortCall.PortId, ct);
            if (port == null)
            {
                return CommandApiResponse.CreateNotFound($"Port with ID {command.PortCall.PortId} not found");
            }

            // Validate Voyage if provided
            if (command.PortCall.VoyageId.HasValue)
            {
                var voyage = await _voyageRepository.GetByIdAsync(command.PortCall.VoyageId.Value, ct);
                if (voyage == null)
                {
                    return CommandApiResponse.CreateNotFound($"Voyage with ID {command.PortCall.VoyageId} not found");
                }
            }

            // Check if PortCallNumber already exists
            var existingPortCall = await _portCallRepository.GetAllAsync(ct);
            if (existingPortCall.Any(pc => pc.PortCallNumber == command.PortCall.PortCallNumber))
            {
                return CommandApiResponse.CreateValidationFailed($"Port call number '{command.PortCall.PortCallNumber}' already exists");
            }

            var portCall = new Domain.Models.PortCall
            {
                VesselId = command.PortCall.VesselId,
                PortId = command.PortCall.PortId,
                VoyageId = command.PortCall.VoyageId,
                PortCallNumber = command.PortCall.PortCallNumber,
                Status = command.PortCall.Status,
                Purpose = command.PortCall.Purpose,
                CallType = command.PortCall.CallType,
                ScheduledArrival = command.PortCall.ScheduledArrival,
                ActualArrival = command.PortCall.ActualArrival,
                ScheduledDeparture = command.PortCall.ScheduledDeparture,
                ActualDeparture = command.PortCall.ActualDeparture,
                ArrivalDelayHours = command.PortCall.ArrivalDelayHours,
                DepartureDelayHours = command.PortCall.DepartureDelayHours,
                TotalDurationHours = command.PortCall.TotalDurationHours,
                BerthNumber = command.PortCall.BerthNumber,
                TerminalName = command.PortCall.TerminalName,
                TerminalOperator = command.PortCall.TerminalOperator,
                BerthType = command.PortCall.BerthType,
                BerthLengthMeters = command.PortCall.BerthLengthMeters,
                BerthDraftMeters = command.PortCall.BerthDraftMeters,
                BerthWidthMeters = command.PortCall.BerthWidthMeters,
                IsAnchorage = command.PortCall.IsAnchorage,
                AnchorageArea = command.PortCall.AnchorageArea,
                PilotRequired = command.PortCall.PilotRequired,
                PilotAssigned = command.PortCall.PilotAssigned,
                PilotName = command.PortCall.PilotName,
                PilotBoardingTime = command.PortCall.PilotBoardingTime,
                TugAssistanceRequired = command.PortCall.TugAssistanceRequired,
                TugCount = command.PortCall.TugCount,
                TugNames = command.PortCall.TugNames,
                CargoOperations = command.PortCall.CargoOperations,
                CargoType = command.PortCall.CargoType,
                CargoWeightMT = command.PortCall.CargoWeightMT,
                CargoVolumeM3 = command.PortCall.CargoVolumeM3,
                ContainerCount = command.PortCall.ContainerCount,
                TEUCount = command.PortCall.TEUCount,
                LoadingWeightMT = command.PortCall.LoadingWeightMT,
                DischargingWeightMT = command.PortCall.DischargingWeightMT,
                CargoHandlingRateMTPerHour = command.PortCall.CargoHandlingRateMTPerHour,
                CargoHandlingStartTime = command.PortCall.CargoHandlingStartTime,
                CargoHandlingEndTime = command.PortCall.CargoHandlingEndTime,
                CargoHandlingDurationHours = command.PortCall.CargoHandlingDurationHours,
                BunkeringRequired = command.PortCall.BunkeringRequired,
                BunkerQuantityMT = command.PortCall.BunkerQuantityMT,
                BunkerType = command.PortCall.BunkerType,
                BunkerSupplier = command.PortCall.BunkerSupplier,
                BunkerCostUSD = command.PortCall.BunkerCostUSD,
                BunkeringStartTime = command.PortCall.BunkeringStartTime,
                BunkeringEndTime = command.PortCall.BunkeringEndTime,
                BunkeringDurationHours = command.PortCall.BunkeringDurationHours,
                FreshWaterRequired = command.PortCall.FreshWaterRequired,
                FreshWaterQuantityMT = command.PortCall.FreshWaterQuantityMT,
                FreshWaterCostUSD = command.PortCall.FreshWaterCostUSD,
                ProvisionsRequired = command.PortCall.ProvisionsRequired,
                ProvisionsSupplier = command.PortCall.ProvisionsSupplier,
                ProvisionsCostUSD = command.PortCall.ProvisionsCostUSD,
                RepairsRequired = command.PortCall.RepairsRequired,
                RepairType = command.PortCall.RepairType,
                RepairDescription = command.PortCall.RepairDescription,
                RepairSupplier = command.PortCall.RepairSupplier,
                RepairCostUSD = command.PortCall.RepairCostUSD,
                RepairStartTime = command.PortCall.RepairStartTime,
                RepairEndTime = command.PortCall.RepairEndTime,
                RepairDurationHours = command.PortCall.RepairDurationHours,
                CrewChangeRequired = command.PortCall.CrewChangeRequired,
                CrewJoiningCount = command.PortCall.CrewJoiningCount,
                CrewLeavingCount = command.PortCall.CrewLeavingCount,
                CrewChangeCostUSD = command.PortCall.CrewChangeCostUSD,
                InspectionRequired = command.PortCall.InspectionRequired,
                InspectionType = command.PortCall.InspectionType,
                InspectionAuthority = command.PortCall.InspectionAuthority,
                InspectionResult = command.PortCall.InspectionResult,
                InspectionDate = command.PortCall.InspectionDate,
                InspectionCostUSD = command.PortCall.InspectionCostUSD,
                CustomsClearanceRequired = command.PortCall.CustomsClearanceRequired,
                CustomsClearanceStatus = command.PortCall.CustomsClearanceStatus,
                CustomsClearanceDate = command.PortCall.CustomsClearanceDate,
                CustomsClearanceCostUSD = command.PortCall.CustomsClearanceCostUSD,
                PortChargesUSD = command.PortCall.PortChargesUSD,
                PilotageCostUSD = command.PortCall.PilotageCostUSD,
                TugCostUSD = command.PortCall.TugCostUSD,
                BerthCostUSD = command.PortCall.BerthCostUSD,
                TerminalCostUSD = command.PortCall.TerminalCostUSD,
                TotalPortCostUSD = command.PortCall.TotalPortCostUSD,
                WeatherConditions = command.PortCall.WeatherConditions,
                SeaState = command.PortCall.SeaState,
                WindSpeedKnots = command.PortCall.WindSpeedKnots,
                WaveHeightMeters = command.PortCall.WaveHeightMeters,
                VisibilityNauticalMiles = command.PortCall.VisibilityNauticalMiles,
                HasIncidents = command.PortCall.HasIncidents,
                IncidentDescription = command.PortCall.IncidentDescription,
                IncidentSeverity = command.PortCall.IncidentSeverity,
                IncidentDate = command.PortCall.IncidentDate,
                IncidentCostUSD = command.PortCall.IncidentCostUSD,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = command.PortCall.CreatedBy,
                Notes = command.PortCall.Notes
            };

            await _portCallRepository.AddAsync(portCall, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return CommandApiResponse.Success(portCall.Id);
        }
        catch (Exception ex)
        {
            return CommandApiResponse.CreateServerError($"An error occurred while creating the port call: {ex.Message}");
        }
    }
}

public class CreatePortCallCommand : ICommand
{
    public CreatePortCallDto PortCall { get; set; } = new();
}
