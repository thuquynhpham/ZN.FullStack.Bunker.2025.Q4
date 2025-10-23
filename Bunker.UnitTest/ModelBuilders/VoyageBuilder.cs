using Bunker.Domain.Models;

namespace Bunker.UnitTest.ModelBuilders
{
    public class VoyageBuilder
    {
        private Voyage _voyage;

        public VoyageBuilder(int id, string voyageNumber, int vesselId)
        {
            _voyage = new Voyage
            {
                Id = id,
                VoyageNumber = voyageNumber,
                VesselId = vesselId,
                Status = "In Progress",
                DeparturePortId = 1,
                ArrivalPortId = 2,
                ScheduledDeparture = DateTime.UtcNow.AddDays(-5),
                ActualDeparture = DateTime.UtcNow.AddDays(-5).AddHours(2),
                ScheduledArrival = DateTime.UtcNow.AddDays(3),
                ActualArrival = null,
                DistanceNauticalMiles = 2500.0m,
                EstimatedDurationHours = 120.0m,
                ActualDurationHours = null,
                AverageSpeedKnots = 18.5m,
                MaxSpeedKnots = 22.0m,
                FuelConsumptionMT = 850.0m,
                FuelCostUSD = 425000.0m,
                TotalCostUSD = 750000.0m,
                RevenueUSD = 1200000.0m,
                ProfitLossUSD = 450000.0m,
                CargoType = "Container",
                CargoWeightMT = 15000.0m,
                CargoVolumeM3 = 25000.0m,
                TEUCount = 2500,
                PassengerCount = null,
                Charterer = "Maersk Line",
                CargoOwner = "Various Shippers",
                CharterType = "Time Charter",
                CharterRateUSDPerDay = 25000.0m,
                CharterDurationDays = 30,
                WeatherConditions = "Good",
                SeaState = "Moderate",
                WindSpeedKnots = 15.0m,
                WaveHeightMeters = 2.5m,
                VisibilityNauticalMiles = 10.0m,
                HasIncidents = false,
                IncidentDescription = null,
                IncidentSeverity = null,
                IncidentDate = null,
                HasDelays = false,
                DelayReason = null,
                DelayDurationHours = null,
                DelayCostUSD = null,
                PortCallCount = 3,
                BunkerOrderCount = 2,
                TotalBunkerQuantityMT = 1200.0m,
                TotalBunkerCostUSD = 600000.0m,
                CaptainName = "Captain John Smith",
                ChiefEngineerName = "Chief Engineer Mike Johnson",
                CrewCount = 22,
                IsInternational = true,
                CrossesEquator = false,
                CrossesDateLine = true,
                TimeZoneChanges = 8,
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                CreatedBy = "System",
                UpdatedBy = "Admin",
                Notes = "Trans-Pacific container voyage with multiple port calls"
            };
        }

        public Voyage Build()
        {
            return _voyage;
        }
    }
}
