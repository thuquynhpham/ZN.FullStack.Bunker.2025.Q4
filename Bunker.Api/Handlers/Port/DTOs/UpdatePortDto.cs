using System.ComponentModel.DataAnnotations;
using Bunker.Domain.Models;

namespace Bunker.Api.Handlers.Port.DTOs;

public class UpdatePortDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(5)]
    public string UNLOCODE { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(100)]
    public string? AlternativeName { get; set; }

    [Required]
    [StringLength(50)]
    public string Country { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string City { get; set; } = string.Empty;

    [StringLength(50)]
    public string? State { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    [StringLength(50)]
    public string? TimeZone { get; set; }

    [Required]
    [StringLength(30)]
    public string PortType { get; set; } = "Seaport";

    [Required]
    [StringLength(20)]
    public string Size { get; set; } = "Regional";

    public decimal? MaxDraft { get; set; }

    public decimal? MaxVesselLength { get; set; }

    public decimal? MaxVesselBeam { get; set; }

    public decimal? MaxDWT { get; set; }

    public int? NumberOfBerths { get; set; }

    public int? NumberOfTerminals { get; set; }

    public bool HasContainerFacilities { get; set; } = false;

    public bool HasBulkFacilities { get; set; } = false;

    public bool HasLiquidFacilities { get; set; } = false;

    public bool HasRoRoFacilities { get; set; } = false;

    public bool HasPassengerFacilities { get; set; } = false;

    public bool HasBunkeringFacilities { get; set; } = false;

    public bool HasRepairFacilities { get; set; } = false;

    public bool Is24Hours { get; set; } = false;

    public bool IsIceFree { get; set; } = true;

    [Required]
    [StringLength(20)]
    public string Status { get; set; } = "Active";

    [StringLength(100)]
    public string? PortAuthority { get; set; }

    [StringLength(20)]
    public string? ContactPhone { get; set; }

    [StringLength(100)]
    public string? ContactEmail { get; set; }

    [StringLength(200)]
    public string? Website { get; set; }

    public decimal? AverageWaitingTimeHours { get; set; }

    public decimal? AverageTurnaroundTimeHours { get; set; }

    public decimal? AnnualCargoThroughputTEU { get; set; }

    public int? AnnualVesselCalls { get; set; }

    [StringLength(50)]
    public string? UpdatedBy { get; set; }

    public string? Notes { get; set; }
}