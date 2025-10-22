namespace Bunker.Api.Handlers.Vessel.DTOs;

public class VesselResponseDto
{
    public int Id { get; set; }
    public string IMO { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string VesselType { get; set; } = string.Empty;
    public string Flag { get; set; } = string.Empty;
    public decimal? GrossTonnage { get; set; }
    public decimal? DeadweightTonnage { get; set; }
    public decimal? LengthOverall { get; set; }
    public decimal? Beam { get; set; }
    public decimal? Draft { get; set; }
    public int? YearBuilt { get; set; }
    public string? Owner { get; set; }
    public string Status { get; set; } = string.Empty;
    public int? MaxCrew { get; set; }
    public decimal? EnginePowerKW { get; set; }
    public decimal? MaxSpeedKnots { get; set; }
    public string? CallSign { get; set; }
    public string? MMSI { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public string? Notes { get; set; }
}