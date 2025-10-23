using System.ComponentModel.DataAnnotations;

namespace Bunker.Api.Handlers.PortCall.DTOs;

public class UpdatePortCallDto
{
    public int Id { get; set; }
    
    [Required]
    public int VesselId { get; set; }
    
    [Required]
    public int PortId { get; set; }
    
    public int? VoyageId { get; set; }
    
    [Required]
    [StringLength(20)]
    public string CallType { get; set; } = string.Empty;
    
    public DateTime? ScheduledArrival { get; set; }
    
    public DateTime? ActualArrival { get; set; }
    
    public DateTime? ScheduledDeparture { get; set; }
    
    public DateTime? ActualDeparture { get; set; }
    
    [StringLength(20)]
    public string? Status { get; set; }
    
    [StringLength(50)]
    public string? UpdatedBy { get; set; }
    
    public string? Notes { get; set; }
}
