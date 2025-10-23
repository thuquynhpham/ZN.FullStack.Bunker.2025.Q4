using System.ComponentModel.DataAnnotations;

namespace Bunker.Api.Handlers.Vessel.DTOs;

public class UpdateVesselDto
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [StringLength(7)]
    public string IMO { get; set; } = string.Empty;
    
    [StringLength(9)]
    public string? MMSI { get; set; }
    
    [StringLength(10)]
    public string? CallSign { get; set; }
    
    [Required]
    [StringLength(50)]
    public string VesselType { get; set; } = string.Empty;
    
    [StringLength(50)]
    public string? Flag { get; set; }
    
    [StringLength(20)]
    public string? Status { get; set; }
    
    public int? YearBuilt { get; set; }
    
    public decimal? Length { get; set; }
    
    public decimal? Width { get; set; }
    
    public decimal? Draft { get; set; }
    
    public decimal? GrossTonnage { get; set; }
    
    public decimal? NetTonnage { get; set; }
    
    public decimal? Deadweight { get; set; }
    
    [StringLength(50)]
    public string? UpdatedBy { get; set; }
    
    public string? Notes { get; set; }
}
