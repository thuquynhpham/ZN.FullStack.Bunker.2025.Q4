using Bunker.Domain.Models;

namespace Bunker.Domain.DBI.SeedData;

public class VoyageDataInitializer
{
    public static Voyage[] Data => new[]
    {
        new Voyage
        {
            Id = 1,
            VesselId = 1,
            VoyageNumber = "V001-2024",
            DeparturePortId = 1, // Singapore
            ArrivalPortId = 2,  // Rotterdam
            ScheduledDeparture = new DateTime(2024, 1, 8, 0, 0, 0, DateTimeKind.Utc),
            ScheduledArrival = new DateTime(2024, 1, 21, 0, 0, 0, DateTimeKind.Utc),
            ActualDeparture = null,
            ActualArrival = null,
            Status = "Planned",
            CargoType = "Containers",
            CargoWeightMT = 50000,
            DistanceNauticalMiles = 8000,
            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System"
        },
        new Voyage
        {
            Id = 2,
            VesselId = 2,
            VoyageNumber = "V002-2024",
            DeparturePortId = 2, // Rotterdam
            ArrivalPortId = 3,   // Los Angeles
            ScheduledDeparture = new DateTime(2024, 1, 11, 0, 0, 0, DateTimeKind.Utc),
            ScheduledArrival = new DateTime(2024, 1, 26, 0, 0, 0, DateTimeKind.Utc),
            ActualDeparture = null,
            ActualArrival = null,
            Status = "Planned",
            CargoType = "Bulk Cargo",
            CargoWeightMT = 75000,
            DistanceNauticalMiles = 6000,
            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System"
        }
    };
}
