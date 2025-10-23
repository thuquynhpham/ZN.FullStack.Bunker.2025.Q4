using Bunker.Api.Handlers._Shared;

namespace Bunker.Api.Handlers.Vessel.DTOs;

public class VesselResponseDto : QueryApiResponse<VesselResponseDto>
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

    public static VesselResponseDto Create(Bunker.Domain.Models.Vessel vessel)
    {
        if (vessel is null) throw new ArgumentNullException(nameof(vessel));

        return new VesselResponseDto
        {
            Id = vessel.Id,
            IMO = vessel.IMO,
            Name = vessel.Name,
            VesselType = vessel.VesselType,
            Flag = vessel.Flag,
            GrossTonnage = vessel.GrossTonnage,
            DeadweightTonnage = vessel.DeadweightTonnage,
            LengthOverall = vessel.LengthOverall,
            Beam = vessel.Beam,
            Draft = vessel.Draft,
            YearBuilt = vessel.YearBuilt,
            Owner = vessel.Owner,
            Status = vessel.Status,
            MaxCrew = vessel.MaxCrew,
            EnginePowerKW = vessel.EnginePowerKW,
            MaxSpeedKnots = vessel.MaxSpeedKnots,
            // Entity model in provided context does not show a CallSign property.
            // Set to null here; adjust to `vessel.CallSign` if entity gains that property.
            CallSign = null,
            MMSI = vessel.MMSI,
            CreatedAt = vessel.CreatedAt,
            UpdatedAt = vessel.UpdatedAt,
            CreatedBy = vessel.CreatedBy,
            UpdatedBy = vessel.UpdatedBy,
            Notes = vessel.Notes
        };
    }
}