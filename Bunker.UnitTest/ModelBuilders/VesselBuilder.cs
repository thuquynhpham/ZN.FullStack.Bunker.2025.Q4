using Bunker.Domain.Models;

namespace Bunker.UnitTest.ModelBuilders
{
    public class VesselBuilder
    {
        private Vessel _vessel;

        public VesselBuilder(int id, string name)
        {
            _vessel = new Vessel
            {
                Id = id,
                Name = name,
                IMO = "9876543", // 7-digit IMO number
                VesselType = "Container Ship",
                Flag = "Panama",
                GrossTonnage = 85000.0m,
                NetTonnage = 65000.0m,
                Deadweight = 120000.0m,
                DeadweightTonnage = 120000.0m,
                Length = 300.0m,
                LengthOverall = 300.0m,
                Width = 40.0m,
                Beam = 40.0m,
                Draft = 14.5m,
                YearBuilt = 2018,
                Owner = "Maersk Line",
                Status = "Active",
                MaxCrew = 25,
                EnginePowerKW = 50000.0m,
                MaxSpeedKnots = 22.5m,
                CallSign = "9V1234",
                MMSI = "123456789",
                CreatedAt = DateTime.UtcNow.AddDays(-60),
                UpdatedAt = DateTime.UtcNow.AddDays(-10),
                CreatedBy = "System",
                UpdatedBy = "Admin",
                Notes = "Modern container vessel with advanced navigation systems"
            };
        }

        public Vessel Build()
        {
            return _vessel;
        }
    }
}
