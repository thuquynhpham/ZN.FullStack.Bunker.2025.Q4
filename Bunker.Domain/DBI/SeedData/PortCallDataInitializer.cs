using Bunker.Domain.Models;

namespace Bunker.Domain.DBI.SeedData;

public class PortCallDataInitializer
{
    public static PortCall[] Data => new[]
    {
        new PortCall
        {
            Id = 1,
            VesselId = 1,
            PortId = 1, // Singapore
            VoyageId = 1,
            PortCallNumber = "PC001-2024",
            ScheduledArrival = new DateTime(2024, 1, 8, 0, 0, 0, DateTimeKind.Utc),
            ScheduledDeparture = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Utc),
            ActualArrival = null,
            ActualDeparture = null,
            Status = "Scheduled",
            Purpose = "Loading",
            CargoOperations = "Container Loading",
            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System"
        },
        new PortCall
        {
            Id = 2,
            VesselId = 2,
            PortId = 2, // Rotterdam
            VoyageId = 2,
            PortCallNumber = "PC002-2024",
            ScheduledArrival = new DateTime(2024, 1, 11, 0, 0, 0, DateTimeKind.Utc),
            ScheduledDeparture = new DateTime(2024, 1, 13, 0, 0, 0, DateTimeKind.Utc),
            ActualArrival = null,
            ActualDeparture = null,
            Status = "Scheduled",
            Purpose = "Loading",
            CargoOperations = "Bulk Cargo Loading",
            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System"
        }
    };
}
