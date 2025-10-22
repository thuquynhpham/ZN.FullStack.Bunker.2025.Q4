using System.ComponentModel.DataAnnotations;

namespace Bunker.Api.Handlers.PortCall.DTOs;

public class CreatePortCallDto
{
    [Required]
    public int VesselId { get; set; }

    [Required]
    public int PortId { get; set; }

    public int? VoyageId { get; set; }

    [Required]
    [StringLength(20)]
    public string PortCallNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(30)]
    public string Status { get; set; } = "Scheduled";

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

    public bool IsAnchorage { get; set; } = false;

    public string? AnchorageArea { get; set; }

    public bool PilotRequired { get; set; } = false;

    public bool PilotAssigned { get; set; } = false;

    public string? PilotName { get; set; }

    public DateTime? PilotBoardingTime { get; set; }

    public bool TugAssistanceRequired { get; set; } = false;

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

    public bool BunkeringRequired { get; set; } = false;

    public decimal? BunkerQuantityMT { get; set; }

    public string? BunkerType { get; set; }

    public string? BunkerSupplier { get; set; }

    public decimal? BunkerCostUSD { get; set; }

    public DateTime? BunkeringStartTime { get; set; }

    public DateTime? BunkeringEndTime { get; set; }

    public decimal? BunkeringDurationHours { get; set; }

    public bool FreshWaterRequired { get; set; } = false;

    public decimal? FreshWaterQuantityMT { get; set; }

    public decimal? FreshWaterCostUSD { get; set; }

    public bool ProvisionsRequired { get; set; } = false;

    public string? ProvisionsSupplier { get; set; }

    public decimal? ProvisionsCostUSD { get; set; }

    public bool RepairsRequired { get; set; } = false;

    public string? RepairType { get; set; }

    public string? RepairDescription { get; set; }

    public string? RepairSupplier { get; set; }

    public decimal? RepairCostUSD { get; set; }

    public DateTime? RepairStartTime { get; set; }

    public DateTime? RepairEndTime { get; set; }

    public decimal? RepairDurationHours { get; set; }

    public bool CrewChangeRequired { get; set; } = false;

    public int? CrewJoiningCount { get; set; }

    public int? CrewLeavingCount { get; set; }

    public decimal? CrewChangeCostUSD { get; set; }

    public bool InspectionRequired { get; set; } = false;

    public string? InspectionType { get; set; }

    public string? InspectionAuthority { get; set; }

    public string? InspectionResult { get; set; }

    public DateTime? InspectionDate { get; set; }

    public decimal? InspectionCostUSD { get; set; }

    public bool CustomsClearanceRequired { get; set; } = false;

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

    public bool HasIncidents { get; set; } = false;

    public string? IncidentDescription { get; set; }

    public string? IncidentSeverity { get; set; }

    public DateTime? IncidentDate { get; set; }

    public decimal? IncidentCostUSD { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    public string? Notes { get; set; }
}