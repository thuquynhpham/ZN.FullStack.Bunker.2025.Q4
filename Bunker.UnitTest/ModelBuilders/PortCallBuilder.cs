using Bunker.Domain.Models;

namespace Bunker.UnitTest.ModelBuilders
{
    public class PortCallBuilder
    {
        private PortCall _portCall;

        public PortCallBuilder(int id, int vesselId, int portId, string portCallNumber)
        {
            _portCall = new PortCall
            {
                Id = id,
                VesselId = vesselId,
                PortId = portId,
                VoyageId = 1,
                PortCallNumber = portCallNumber,
                Status = "In Progress",
                Purpose = "Cargo Operations",
                CallType = "Scheduled",
                ScheduledArrival = DateTime.UtcNow.AddDays(-2),
                ActualArrival = DateTime.UtcNow.AddDays(-2).AddHours(1),
                ScheduledDeparture = DateTime.UtcNow.AddDays(1),
                ActualDeparture = null,
                ArrivalDelayHours = 1.0m,
                DepartureDelayHours = null,
                TotalDurationHours = null,
                BerthNumber = "Berth 5",
                TerminalName = "Container Terminal A",
                TerminalOperator = "Port Authority",
                BerthType = "Container Berth",
                BerthLengthMeters = 350.0m,
                BerthDraftMeters = 15.0m,
                BerthWidthMeters = 50.0m,
                IsAnchorage = false,
                AnchorageArea = null,
                PilotRequired = true,
                PilotAssigned = true,
                PilotName = "Pilot Robert Wilson",
                PilotBoardingTime = DateTime.UtcNow.AddDays(-2).AddHours(1).AddMinutes(30),
                TugAssistanceRequired = true,
                TugCount = 2,
                TugNames = "Tug Alpha, Tug Beta",
                CargoOperations = "Loading and Discharging",
                CargoType = "Container",
                CargoWeightMT = 8000.0m,
                CargoVolumeM3 = 12000.0m,
                ContainerCount = 1200,
                TEUCount = 1200,
                LoadingWeightMT = 5000.0m,
                DischargingWeightMT = 3000.0m,
                CargoHandlingRateMTPerHour = 150.0m,
                CargoHandlingStartTime = DateTime.UtcNow.AddDays(-2).AddHours(2),
                CargoHandlingEndTime = DateTime.UtcNow.AddDays(-1).AddHours(8),
                CargoHandlingDurationHours = 18.0m,
                BunkeringRequired = true,
                BunkerQuantityMT = 500.0m,
                BunkerType = "MGO",
                BunkerSupplier = "Shell Marine",
                BunkerCostUSD = 250000.0m,
                BunkeringStartTime = DateTime.UtcNow.AddDays(-1).AddHours(10),
                BunkeringEndTime = DateTime.UtcNow.AddDays(-1).AddHours(14),
                BunkeringDurationHours = 4.0m,
                FreshWaterRequired = true,
                FreshWaterQuantityMT = 100.0m,
                FreshWaterCostUSD = 5000.0m,
                ProvisionsRequired = true,
                ProvisionsSupplier = "Marine Provisions Ltd",
                ProvisionsCostUSD = 15000.0m,
                RepairsRequired = false,
                RepairType = null,
                RepairDescription = null,
                RepairSupplier = null,
                RepairCostUSD = null,
                RepairStartTime = null,
                RepairEndTime = null,
                RepairDurationHours = null,
                CrewChangeRequired = false,
                CrewJoiningCount = null,
                CrewLeavingCount = null,
                CrewChangeCostUSD = null,
                InspectionRequired = true,
                InspectionType = "Port State Control",
                InspectionAuthority = "US Coast Guard",
                InspectionResult = "Passed",
                InspectionDate = DateTime.UtcNow.AddDays(-1),
                InspectionCostUSD = 2000.0m,
                CustomsClearanceRequired = true,
                CustomsClearanceStatus = "Cleared",
                CustomsClearanceDate = DateTime.UtcNow.AddDays(-1).AddHours(12),
                CustomsClearanceCostUSD = 5000.0m,
                PortChargesUSD = 45000.0m,
                PilotageCostUSD = 8000.0m,
                TugCostUSD = 12000.0m,
                BerthCostUSD = 25000.0m,
                TerminalCostUSD = 20000.0m,
                TotalPortCostUSD = 110000.0m,
                WeatherConditions = "Good",
                SeaState = "Calm",
                WindSpeedKnots = 8.0m,
                WaveHeightMeters = 1.0m,
                VisibilityNauticalMiles = 12.0m,
                HasIncidents = false,
                IncidentDescription = null,
                IncidentSeverity = null,
                IncidentDate = null,
                IncidentCostUSD = null,
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                UpdatedAt = DateTime.UtcNow.AddHours(-2),
                CreatedBy = "System",
                UpdatedBy = "Port Operations",
                Notes = "Routine container port call with cargo operations and bunkering"
            };
        }

        public PortCallBuilder WithVessel(Domain.Models.Vessel vessel)
        {
            _portCall.VesselId = vessel.Id;
            _portCall.Vessel = vessel;
            return this;
        }

        public PortCallBuilder WithPort(Domain.Models.Port port)
        {
            _portCall.PortId = port.Id;
            _portCall.Port = port;
            return this;
        }

        public PortCallBuilder WithVoyage(Domain.Models.Voyage voyage)
        {
            _portCall.VoyageId = voyage.Id;
            _portCall.Voyage = voyage;
            return this;
        }

        public PortCallBuilder WithStatus(string status)
        {
            _portCall.Status = status;
            return this;
        }

        public PortCallBuilder WithCallType(string callType)
        {
            _portCall.CallType = callType;
            return this;
        }

        public PortCallBuilder WithPurpose(string purpose)
        {
            _portCall.Purpose = purpose;
            return this;
        }

        public PortCallBuilder WithScheduledArrival(DateTime scheduledArrival)
        {
            _portCall.ScheduledArrival = scheduledArrival;
            return this;
        }

        public PortCallBuilder WithActualArrival(DateTime actualArrival)
        {
            _portCall.ActualArrival = actualArrival;
            return this;
        }

        public PortCallBuilder WithScheduledDeparture(DateTime scheduledDeparture)
        {
            _portCall.ScheduledDeparture = scheduledDeparture;
            return this;
        }

        public PortCallBuilder WithActualDeparture(DateTime actualDeparture)
        {
            _portCall.ActualDeparture = actualDeparture;
            return this;
        }

        public PortCallBuilder WithBerthNumber(string berthNumber)
        {
            _portCall.BerthNumber = berthNumber;
            return this;
        }

        public PortCallBuilder WithTerminalName(string terminalName)
        {
            _portCall.TerminalName = terminalName;
            return this;
        }

        public PortCallBuilder WithCargoType(string cargoType)
        {
            _portCall.CargoType = cargoType;
            return this;
        }

        public PortCallBuilder WithBunkeringRequired(bool bunkeringRequired)
        {
            _portCall.BunkeringRequired = bunkeringRequired;
            return this;
        }

        public PortCallBuilder WithBunkerQuantity(decimal bunkerQuantity)
        {
            _portCall.BunkerQuantityMT = bunkerQuantity;
            return this;
        }

        public PortCallBuilder WithBunkerType(string bunkerType)
        {
            _portCall.BunkerType = bunkerType;
            return this;
        }

        public PortCallBuilder WithBunkerCost(decimal bunkerCost)
        {
            _portCall.BunkerCostUSD = bunkerCost;
            return this;
        }

        public PortCallBuilder WithTotalPortCost(decimal totalPortCost)
        {
            _portCall.TotalPortCostUSD = totalPortCost;
            return this;
        }

        public PortCallBuilder WithNotes(string notes)
        {
            _portCall.Notes = notes;
            return this;
        }

        public PortCall Build()
        {
            return _portCall;
        }
    }
}
