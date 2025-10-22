namespace Bunker.Api.Handlers.Voyage.DTOs;

public class VoyageResponseDto
{
    public int Id { get; set; }
    public string VoyageNumber { get; set; } = string.Empty;
    public int VesselId { get; set; }
    public string Status { get; set; } = string.Empty;
    public int? DeparturePortId { get; set; }
    public int? ArrivalPortId { get; set; }
    public DateTime? ScheduledDeparture { get; set; }
    public DateTime? ActualDeparture { get; set; }
    public DateTime? ScheduledArrival { get; set; }
    public DateTime? ActualArrival { get; set; }
    public decimal? DistanceNauticalMiles { get; set; }
    public decimal? EstimatedDurationHours { get; set; }
    public decimal? ActualDurationHours { get; set; }
    public decimal? AverageSpeedKnots { get; set; }
    public decimal? MaxSpeedKnots { get; set; }
    public decimal? FuelConsumptionMT { get; set; }
    public decimal? FuelCostUSD { get; set; }
    public decimal? TotalCostUSD { get; set; }
    public decimal? RevenueUSD { get; set; }
    public decimal? ProfitLossUSD { get; set; }
    public string? CargoType { get; set; }
    public decimal? CargoWeightMT { get; set; }
    public decimal? CargoVolumeM3 { get; set; }
    public int? TEUCount { get; set; }
    public int? PassengerCount { get; set; }
    public string? Charterer { get; set; }
    public string? CargoOwner { get; set; }
    public string? CharterType { get; set; }
    public decimal? CharterRateUSDPerDay { get; set; }
    public int? CharterDurationDays { get; set; }
    public string? WeatherConditions { get; set; }
    public string? SeaState { get; set; }
    public decimal? WindSpeedKnots { get; set; }
    public decimal? WaveHeightMeters { get; set; }
    public decimal? VisibilityNauticalMiles { get; set; }
    public bool HasIncidents { get; set; }
    public string? IncidentDescription { get; set; }
    public string? IncidentSeverity { get; set; }
    public DateTime? IncidentDate { get; set; }
    public bool HasDelays { get; set; }
    public string? DelayReason { get; set; }
    public decimal? DelayDurationHours { get; set; }
    public decimal? DelayCostUSD { get; set; }
    public int PortCallCount { get; set; }
    public int BunkerOrderCount { get; set; }
    public decimal? TotalBunkerQuantityMT { get; set; }
    public decimal? TotalBunkerCostUSD { get; set; }
    public string? CaptainName { get; set; }
    public string? ChiefEngineerName { get; set; }
    public int? CrewCount { get; set; }
    public bool IsInternational { get; set; }
    public bool CrossesEquator { get; set; }
    public bool CrossesDateLine { get; set; }
    public int? TimeZoneChanges { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public string? Notes { get; set; }
    
    // Navigation properties
    public string? VesselName { get; set; }
    public string? DeparturePortName { get; set; }
    public string? ArrivalPortName { get; set; }
}