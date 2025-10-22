using Bunker.Domain.Models;

namespace Bunker.Domain.DBI.SeedData;

public class BunkerOrderDataInitializer
{
    public static BunkerOrder[] Data => new[]
    {
        new BunkerOrder
        {
            Id = 1,
            VesselId = 1,
            PortId = 1, // Singapore
            VoyageId = 1,
            PortCallId = 1,
            OrderNumber = "BO001-2024",
            FuelType = "MGO",
            QuantityMT = 500,
            UnitPriceUSDPerMT = 650,
            TotalPriceUSD = 325000,
            Currency = "USD",
            RequestedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ScheduledDeliveryDate = new DateTime(2024, 1, 9, 0, 0, 0, DateTimeKind.Utc),
            ActualDeliveryDate = null,
            Status = "Requested",
            SupplierName = "Singapore Fuel Co",
            DeliveryMethod = "Barge",
            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System"
        },
        new BunkerOrder
        {
            Id = 2,
            VesselId = 2,
            PortId = 2, // Rotterdam
            VoyageId = 2,
            PortCallId = 2,
            OrderNumber = "BO002-2024",
            FuelType = "IFO 380",
            QuantityMT = 1000,
            UnitPriceUSDPerMT = 450,
            TotalPriceUSD = 450000,
            Currency = "USD",
            RequestedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            ScheduledDeliveryDate = new DateTime(2024, 1, 12, 0, 0, 0, DateTimeKind.Utc),
            ActualDeliveryDate = null,
            Status = "Requested",
            SupplierName = "Rotterdam Bunker Services",
            DeliveryMethod = "Barge",
            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            CreatedBy = "System"
        }
    };
}
