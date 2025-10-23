using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bunker.Domain.Models;

[Table("Vessels")]
public class Vessel
{
    [Key]
    public int Id { get; set; }

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

    public decimal? NetTonnage { get; set; }

    public decimal? Deadweight { get; set; }

    public decimal? DeadweightTonnage { get; set; }

    public decimal? Length { get; set; }

    public decimal? LengthOverall { get; set; }

    public decimal? Width { get; set; }

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

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [StringLength(50)]
    public string? UpdatedBy { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<Voyage> Voyages { get; set; } = new List<Voyage>();

    public virtual ICollection<PortCall> PortCalls { get; set; } = new List<PortCall>();

    public virtual ICollection<BunkerOrder> BunkerOrders { get; set; } = new List<BunkerOrder>();
}
