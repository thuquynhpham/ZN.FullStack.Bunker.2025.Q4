using System.ComponentModel.DataAnnotations;

namespace Bunker.Api.Handlers.Voyage.DTOs;

public class UpdateVoyageDto
{
    public int Id { get; set; }
    
    [Required]
    public int VesselId { get; set; }
    
    public int? DeparturePortId { get; set; }
    
    public int? ArrivalPortId { get; set; }
    
    [Required]
    [StringLength(50)]
    public string VoyageNumber { get; set; } = string.Empty;
    
    public DateTime? ScheduledDeparture { get; set; }
    
    public DateTime? ActualDeparture { get; set; }
    
    public DateTime? ScheduledArrival { get; set; }
    
    public DateTime? ActualArrival { get; set; }
    
    [StringLength(20)]
    public string? Status { get; set; }
    
    [StringLength(50)]
    public string? UpdatedBy { get; set; }
    
    public string? Notes { get; set; }
}
