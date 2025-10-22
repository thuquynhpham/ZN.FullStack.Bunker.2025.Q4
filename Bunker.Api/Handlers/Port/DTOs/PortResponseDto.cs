namespace Bunker.Api.Handlers.Port.DTOs;

public class PortResponseDto
{
    public int Id { get; set; }
    public string UNLOCODE { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? AlternativeName { get; set; }
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? State { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public string? TimeZone { get; set; }
    public string PortType { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
    public decimal? MaxDraft { get; set; }
    public decimal? MaxVesselLength { get; set; }
    public decimal? MaxVesselBeam { get; set; }
    public decimal? MaxDWT { get; set; }
    public int? NumberOfBerths { get; set; }
    public int? NumberOfTerminals { get; set; }
    public bool HasContainerFacilities { get; set; }
    public bool HasBulkFacilities { get; set; }
    public bool HasLiquidFacilities { get; set; }
    public bool HasRoRoFacilities { get; set; }
    public bool HasPassengerFacilities { get; set; }
    public bool HasBunkeringFacilities { get; set; }
    public bool HasRepairFacilities { get; set; }
    public bool Is24Hours { get; set; }
    public bool IsIceFree { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? PortAuthority { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }
    public string? Website { get; set; }
    public decimal? AverageWaitingTimeHours { get; set; }
    public decimal? AverageTurnaroundTimeHours { get; set; }
    public decimal? AnnualCargoThroughputTEU { get; set; }
    public int? AnnualVesselCalls { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public string? Notes { get; set; }

    public static PortResponseDto Create(Domain.Models.Port port)
    {
        return new PortResponseDto
        {
            Id = port.Id,
            UNLOCODE = port.UNLOCODE,
            Name = port.Name,
            AlternativeName = port.AlternativeName,
            Country = port.Country,
            City = port.City,
            State = port.State,
            Latitude = port.Latitude,
            Longitude = port.Longitude,
            TimeZone = port.TimeZone,
            PortType = port.PortType,
            Size = port.Size,
            MaxDraft = port.MaxDraft,
            MaxVesselLength = port.MaxVesselLength,
            MaxVesselBeam = port.MaxVesselBeam,
            MaxDWT = port.MaxDWT,
            NumberOfBerths = port.NumberOfBerths,
            NumberOfTerminals = port.NumberOfTerminals,
            HasContainerFacilities = port.HasContainerFacilities,
            HasBulkFacilities = port.HasBulkFacilities,
            HasLiquidFacilities = port.HasLiquidFacilities,
            HasRoRoFacilities = port.HasRoRoFacilities,
            HasPassengerFacilities = port.HasPassengerFacilities,
            HasBunkeringFacilities = port.HasBunkeringFacilities,
            HasRepairFacilities = port.HasRepairFacilities,
            Is24Hours = port.Is24Hours,
            IsIceFree = port.IsIceFree,
            Status = port.Status,
            PortAuthority = port.PortAuthority,
            ContactPhone = port.ContactPhone,
            ContactEmail = port.ContactEmail,
            Website = port.Website,
            AverageWaitingTimeHours = port.AverageWaitingTimeHours,
            AverageTurnaroundTimeHours = port.AverageTurnaroundTimeHours,
            AnnualCargoThroughputTEU = port.AnnualCargoThroughputTEU,
            AnnualVesselCalls = port.AnnualVesselCalls,
            CreatedAt = port.CreatedAt,
            UpdatedAt = port.UpdatedAt,
            CreatedBy = port.CreatedBy,
            UpdatedBy = port.UpdatedBy,
            Notes = port.Notes
        };
    }
}