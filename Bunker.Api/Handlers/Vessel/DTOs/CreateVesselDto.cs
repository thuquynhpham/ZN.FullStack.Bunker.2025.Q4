using System.ComponentModel.DataAnnotations;
using Bunker.Domain.Models;

namespace Bunker.Api.Handlers.Vessel.DTOs;

public class CreateVesselDto
{
    [Required]
    [StringLength(7)]
    public string IMO { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string VesselType { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Flag { get; set; } = string.Empty;

    public decimal? GrossTonnage { get; set; }

    public decimal? DeadweightTonnage { get; set; }

    public decimal? LengthOverall { get; set; }

    public decimal? Beam { get; set; }

    public decimal? Draft { get; set; }

    public int? YearBuilt { get; set; }

    [StringLength(100)]
    public string? Owner { get; set; }

    [Required]
    [StringLength(20)]
    public string Status { get; set; } = "Active";

    public int? MaxCrew { get; set; }

    public decimal? EnginePowerKW { get; set; }

    public decimal? MaxSpeedKnots { get; set; }

    [StringLength(10)]
    public string? CallSign { get; set; }

    [StringLength(9)]
    public string? MMSI { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    public string? Notes { get; set; }

}