using Bunker.Domain.Models;

namespace Bunker.Domain.DBI.SeedData;

public class PortDataInitializer
{
    public static Port[] Data => new[]
    {
        new Port
        {
            Id = 1,
            UNLOCODE = "SGSIN",
            Name = "Port of Singapore",
            Country = "Singapore",
            City = "Singapore",
            Latitude = 1.2966m,
            Longitude = 103.7764m,
            TimeZone = "Asia/Singapore",
            PortType = "Container Port",
            Size = "Major",
            MaxDraft = 16,
            MaxVesselLength = 400,
            MaxVesselBeam = 60,
            HasContainerFacilities = true,
            HasBunkeringFacilities = true,
            Is24Hours = true,
            Status = "Active",
            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System"
        },
        new Port
        {
            Id = 2,
            UNLOCODE = "NLRTM",
            Name = "Port of Rotterdam",
            Country = "Netherlands",
            City = "Rotterdam",
            Latitude = 51.9225m,
            Longitude = 4.4792m,
            TimeZone = "Europe/Amsterdam",
            PortType = "Container Port",
            Size = "Major",
            MaxDraft = 20,
            MaxVesselLength = 400,
            MaxVesselBeam = 60,
            HasContainerFacilities = true,
            HasBunkeringFacilities = true,
            Is24Hours = true,
            Status = "Active",
            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System"
        },
        new Port
        {
            Id = 3,
            UNLOCODE = "USLAX",
            Name = "Port of Los Angeles",
            Country = "United States",
            City = "Los Angeles",
            Latitude = 33.7175m,
            Longitude = -118.2728m,
            TimeZone = "America/Los_Angeles",
            PortType = "Container Port",
            Size = "Major",
            MaxDraft = 15,
            MaxVesselLength = 400,
            MaxVesselBeam = 60,
            HasContainerFacilities = true,
            HasBunkeringFacilities = true,
            Is24Hours = true,
            Status = "Active",
            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System"
        },
        new Port
        {
            Id = 4,
            UNLOCODE = "DEHAM",
            Name = "Port of Hamburg",
            Country = "Germany",
            City = "Hamburg",
            Latitude = 53.5511m,
            Longitude = 9.9937m,
            TimeZone = "Europe/Berlin",
            PortType = "Container Port",
            Size = "Major",
            MaxDraft = 14,
            MaxVesselLength = 350,
            MaxVesselBeam = 50,
            HasContainerFacilities = true,
            HasBunkeringFacilities = true,
            Is24Hours = true,
            Status = "Active",
            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System"
        }
    };
}
