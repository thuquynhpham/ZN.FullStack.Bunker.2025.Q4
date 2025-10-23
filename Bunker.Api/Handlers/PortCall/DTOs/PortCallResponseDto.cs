using Bunker.Api.Handlers._Shared;

namespace Bunker.Api.Handlers.PortCall.DTOs;

public class PortCallResponseDto : QueryApiResponse<PortCallResponseDto>
{
    public int Id { get; set; }
    public int VesselId { get; set; }
    public int PortId { get; set; }
    public int? VoyageId { get; set; }
    public string PortCallNumber { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string? Purpose { get; set; }
    public string? CallType { get; set; }
    public DateTime? ScheduledArrival { get; set; }
    public DateTime? ActualArrival { get; set; }
    public DateTime? ScheduledDeparture { get; set; }
    public DateTime? ActualDeparture { get; set; }
    public decimal? ArrivalDelayHours { get; set; }
    public decimal? DepartureDelayHours { get; set; }
    public decimal? TotalDurationHours { get; set; }
    public string? BerthNumber { get; set; }
    public string? TerminalName { get; set; }
    public string? TerminalOperator { get; set; }
    public string? BerthType { get; set; }
    public decimal? BerthLengthMeters { get; set; }
    public decimal? BerthDraftMeters { get; set; }
    public decimal? BerthWidthMeters { get; set; }
    public bool IsAnchorage { get; set; }
    public string? AnchorageArea { get; set; }
    public bool PilotRequired { get; set; }
    public bool PilotAssigned { get; set; }
    public string? PilotName { get; set; }
    public DateTime? PilotBoardingTime { get; set; }
    public bool TugAssistanceRequired { get; set; }
    public int? TugCount { get; set; }
    public string? TugNames { get; set; }
    public string? CargoOperations { get; set; }
    public string? CargoType { get; set; }
    public decimal? CargoWeightMT { get; set; }
    public decimal? CargoVolumeM3 { get; set; }
    public int? ContainerCount { get; set; }
    public int? TEUCount { get; set; }
    public decimal? LoadingWeightMT { get; set; }
    public decimal? DischargingWeightMT { get; set; }
    public decimal? CargoHandlingRateMTPerHour { get; set; }
    public DateTime? CargoHandlingStartTime { get; set; }
    public DateTime? CargoHandlingEndTime { get; set; }
    public decimal? CargoHandlingDurationHours { get; set; }
    public bool BunkeringRequired { get; set; }
    public decimal? BunkerQuantityMT { get; set; }
    public string? BunkerType { get; set; }
    public string? BunkerSupplier { get; set; }
    public decimal? BunkerCostUSD { get; set; }
    public DateTime? BunkeringStartTime { get; set; }
    public DateTime? BunkeringEndTime { get; set; }
    public decimal? BunkeringDurationHours { get; set; }
    public bool FreshWaterRequired { get; set; }
    public decimal? FreshWaterQuantityMT { get; set; }
    public decimal? FreshWaterCostUSD { get; set; }
    public bool ProvisionsRequired { get; set; }
    public string? ProvisionsSupplier { get; set; }
    public decimal? ProvisionsCostUSD { get; set; }
    public bool RepairsRequired { get; set; }
    public string? RepairType { get; set; }
    public string? RepairDescription { get; set; }
    public string? RepairSupplier { get; set; }
    public decimal? RepairCostUSD { get; set; }
    public DateTime? RepairStartTime { get; set; }
    public DateTime? RepairEndTime { get; set; }
    public decimal? RepairDurationHours { get; set; }
    public bool CrewChangeRequired { get; set; }
    public int? CrewJoiningCount { get; set; }
    public int? CrewLeavingCount { get; set; }
    public decimal? CrewChangeCostUSD { get; set; }
    public bool InspectionRequired { get; set; }
    public string? InspectionType { get; set; }
    public string? InspectionAuthority { get; set; }
    public string? InspectionResult { get; set; }
    public DateTime? InspectionDate { get; set; }
    public decimal? InspectionCostUSD { get; set; }
    public bool CustomsClearanceRequired { get; set; }
    public string? CustomsClearanceStatus { get; set; }
    public DateTime? CustomsClearanceDate { get; set; }
    public decimal? CustomsClearanceCostUSD { get; set; }
    public decimal? PortChargesUSD { get; set; }
    public decimal? PilotageCostUSD { get; set; }
    public decimal? TugCostUSD { get; set; }
    public decimal? BerthCostUSD { get; set; }
    public decimal? TerminalCostUSD { get; set; }
    public decimal? TotalPortCostUSD { get; set; }
    public string? WeatherConditions { get; set; }
    public string? SeaState { get; set; }
    public decimal? WindSpeedKnots { get; set; }
    public decimal? WaveHeightMeters { get; set; }
    public decimal? VisibilityNauticalMiles { get; set; }
    public bool HasIncidents { get; set; }
    public string? IncidentDescription { get; set; }
    public string? IncidentSeverity { get; set; }
    public DateTime? IncidentDate { get; set; }
    public decimal? IncidentCostUSD { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public string? Notes { get; set; }
    
    // Navigation properties
    public string? VesselName { get; set; }
    public string? PortName { get; set; }
    public string? VoyageNumber { get; set; }

    public static PortCallResponseDto Create(Bunker.Domain.Models.PortCall portCall)
    {
        return new PortCallResponseDto
        {
            Id = portCall.Id,
            VesselId = portCall.VesselId,
            PortId = portCall.PortId,
            VoyageId = portCall.VoyageId,
            PortCallNumber = portCall.PortCallNumber,
            Status = portCall.Status,
            Purpose = portCall.Purpose,
            CallType = portCall.CallType,
            ScheduledArrival = portCall.ScheduledArrival,
            ActualArrival = portCall.ActualArrival,
            ScheduledDeparture = portCall.ScheduledDeparture,
            ActualDeparture = portCall.ActualDeparture,
            ArrivalDelayHours = portCall.ArrivalDelayHours,
            DepartureDelayHours = portCall.DepartureDelayHours,
            TotalDurationHours = portCall.TotalDurationHours,
            BerthNumber = portCall.BerthNumber,
            TerminalName = portCall.TerminalName,
            TerminalOperator = portCall.TerminalOperator,
            BerthType = portCall.BerthType,
            BerthLengthMeters = portCall.BerthLengthMeters,
            BerthDraftMeters = portCall.BerthDraftMeters,
            BerthWidthMeters = portCall.BerthWidthMeters,
            IsAnchorage = portCall.IsAnchorage,
            AnchorageArea = portCall.AnchorageArea,
            PilotRequired = portCall.PilotRequired,
            PilotAssigned = portCall.PilotAssigned,
            PilotName = portCall.PilotName,
            PilotBoardingTime = portCall.PilotBoardingTime,
            TugAssistanceRequired = portCall.TugAssistanceRequired,
            TugCount = portCall.TugCount,
            TugNames = portCall.TugNames,
            CargoOperations = portCall.CargoOperations,
            CargoType = portCall.CargoType,
            CargoWeightMT = portCall.CargoWeightMT,
            CargoVolumeM3 = portCall.CargoVolumeM3,
            ContainerCount = portCall.ContainerCount,
            TEUCount = portCall.TEUCount,
            LoadingWeightMT = portCall.LoadingWeightMT,
            DischargingWeightMT = portCall.DischargingWeightMT,
            CargoHandlingRateMTPerHour = portCall.CargoHandlingRateMTPerHour,
            CargoHandlingStartTime = portCall.CargoHandlingStartTime,
            CargoHandlingEndTime = portCall.CargoHandlingEndTime,
            CargoHandlingDurationHours = portCall.CargoHandlingDurationHours,
            BunkeringRequired = portCall.BunkeringRequired,
            BunkerQuantityMT = portCall.BunkerQuantityMT,
            BunkerType = portCall.BunkerType,
            BunkerSupplier = portCall.BunkerSupplier,
            BunkerCostUSD = portCall.BunkerCostUSD,
            BunkeringStartTime = portCall.BunkeringStartTime,
            BunkeringEndTime = portCall.BunkeringEndTime,
            BunkeringDurationHours = portCall.BunkeringDurationHours,
            FreshWaterRequired = portCall.FreshWaterRequired,
            FreshWaterQuantityMT = portCall.FreshWaterQuantityMT,
            FreshWaterCostUSD = portCall.FreshWaterCostUSD,
            ProvisionsRequired = portCall.ProvisionsRequired,
            ProvisionsSupplier = portCall.ProvisionsSupplier,
            ProvisionsCostUSD = portCall.ProvisionsCostUSD,
            RepairsRequired = portCall.RepairsRequired,
            RepairType = portCall.RepairType,
            RepairDescription = portCall.RepairDescription,
            RepairSupplier = portCall.RepairSupplier,
            RepairCostUSD = portCall.RepairCostUSD,
            RepairStartTime = portCall.RepairStartTime,
            RepairEndTime = portCall.RepairEndTime,
            RepairDurationHours = portCall.RepairDurationHours,
            CrewChangeRequired = portCall.CrewChangeRequired,
            CrewJoiningCount = portCall.CrewJoiningCount,
            CrewLeavingCount = portCall.CrewLeavingCount,
            CrewChangeCostUSD = portCall.CrewChangeCostUSD,
            InspectionRequired = portCall.InspectionRequired,
            InspectionType = portCall.InspectionType,
            InspectionAuthority = portCall.InspectionAuthority,
            InspectionResult = portCall.InspectionResult,
            InspectionDate = portCall.InspectionDate,
            InspectionCostUSD = portCall.InspectionCostUSD,
            CustomsClearanceRequired = portCall.CustomsClearanceRequired,
            CustomsClearanceStatus = portCall.CustomsClearanceStatus,
            CustomsClearanceDate = portCall.CustomsClearanceDate,
            CustomsClearanceCostUSD = portCall.CustomsClearanceCostUSD,
            PortChargesUSD = portCall.PortChargesUSD,
            PilotageCostUSD = portCall.PilotageCostUSD,
            TugCostUSD = portCall.TugCostUSD,
            BerthCostUSD = portCall.BerthCostUSD,
            TerminalCostUSD = portCall.TerminalCostUSD,
            TotalPortCostUSD = portCall.TotalPortCostUSD,
            WeatherConditions = portCall.WeatherConditions,
            SeaState = portCall.SeaState,
            WindSpeedKnots = portCall.WindSpeedKnots,
            WaveHeightMeters = portCall.WaveHeightMeters,
            VisibilityNauticalMiles = portCall.VisibilityNauticalMiles,
            HasIncidents = portCall.HasIncidents,
            IncidentDescription = portCall.IncidentDescription,
            IncidentSeverity = portCall.IncidentSeverity,
            IncidentDate = portCall.IncidentDate,
            IncidentCostUSD = portCall.IncidentCostUSD,
            CreatedAt = portCall.CreatedAt,
            UpdatedAt = portCall.UpdatedAt,
            CreatedBy = portCall.CreatedBy,
            UpdatedBy = portCall.UpdatedBy,
            Notes = portCall.Notes,
            VesselName = portCall.Vessel?.Name,
            PortName = portCall.Port?.Name,
            VoyageNumber = portCall.Voyage?.VoyageNumber
        };
    }
}