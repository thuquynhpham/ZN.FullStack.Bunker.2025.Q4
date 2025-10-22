using Bunker.Domain.Models;

namespace Bunker.Domain.DBI.SeedData;

public class VesselDataInitializer
{
    public static Vessel[] Data => new[]
    {
        new Vessel
        {
            Id = 1,
            IMO = "1234567",
            Name = "MV Atlantic Star",
            VesselType = "Container Ship",
            Flag = "Panama",
            GrossTonnage = 50000,
            DeadweightTonnage = 60000,
            LengthOverall = 200,
            Beam = 32,
            Draft = 12,
            YearBuilt = 2015,
            Owner = "Atlantic Shipping Ltd",
            Status = "Active",
            MaxCrew = 25,
            EnginePowerKW = 15000,
            MaxSpeedKnots = 22,
            CallSign = "ABCD123",
            MMSI = "123456789",
            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System"
        },
        new Vessel
        {
            Id = 2,
            IMO = "2345678",
            Name = "MV Pacific Explorer",
            VesselType = "Bulk Carrier",
            Flag = "Liberia",
            GrossTonnage = 75000,
            DeadweightTonnage = 85000,
            LengthOverall = 250,
            Beam = 40,
            Draft = 15,
            YearBuilt = 2018,
            Owner = "Pacific Maritime Corp",
            Status = "Active",
            MaxCrew = 30,
            EnginePowerKW = 20000,
            MaxSpeedKnots = 18,
            CallSign = "EFGH456",
            MMSI = "234567890",
            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System"
        },
        new Vessel
        {
            Id = 3,
            IMO = "3456789",
            Name = "MV Indian Ocean",
            VesselType = "Tanker",
            Flag = "Marshall Islands",
            GrossTonnage = 100000,
            DeadweightTonnage = 120000,
            LengthOverall = 300,
            Beam = 50,
            Draft = 18,
            YearBuilt = 2020,
            Owner = "Ocean Transport Ltd",
            Status = "Active",
            MaxCrew = 35,
            EnginePowerKW = 25000,
            MaxSpeedKnots = 16,
            CallSign = "IJKL789",
            MMSI = "345678901",
            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System"
        }
    };
}
