using Bunker.Domain.Models;

namespace Bunker.UnitTest.ModelBuilders
{
    public class PortBuilder
    {
        private Port _port;

        public PortBuilder(int id, string name)
        {
            _port = new Port
            {
                Id = id,
                Name = name,
                UNLOCODE = "USNYC", // New York UNLOCODE
                Country = "United States",
                City = "New York",
                PortType = "Seaport",
                Size = "Major",
                Status = "Active",
                AlternativeName = "Port of New York",
                State = "New York",
                Latitude = 40.6892m,
                Longitude = -74.0445m,
                TimeZone = "America/New_York",
                MaxDraft = 15.5m,
                MaxVesselLength = 400.0m,
                MaxVesselBeam = 60.0m,
                MaxDWT = 150000.0m,
                NumberOfBerths = 25,
                NumberOfTerminals = 8,
                HasContainerFacilities = true,
                HasBulkFacilities = true,
                HasLiquidFacilities = true,
                HasRoRoFacilities = true,
                HasPassengerFacilities = true,
                HasBunkeringFacilities = true,
                HasRepairFacilities = true,
                Is24Hours = true,
                IsIceFree = true,
                PortAuthority = "Port Authority of New York and New Jersey",
                ContactPhone = "+1-212-435-7000",
                ContactEmail = "info@panynj.gov",
                Website = "https://www.panynj.gov",
                AverageWaitingTimeHours = 12.5m,
                AverageTurnaroundTimeHours = 24.0m,
                AnnualCargoThroughputTEU = 7500000.0m,
                AnnualVesselCalls = 4500,
                CreatedAt = DateTime.UtcNow.AddDays(-30),
                UpdatedAt = DateTime.UtcNow.AddDays(-5),
                CreatedBy = "System",
                UpdatedBy = "Admin",
                Notes = "Major container port with extensive facilities"
            };
        }

        public Port Build()
        {
            return _port;
        }

        // Fluent methods for setting different attributes
        public PortBuilder WithCountry(string country)
        {
            _port.Country = country;
            return this;
        }

        public PortBuilder WithPortType(string portType)
        {
            _port.PortType = portType;
            return this;
        }

        public PortBuilder WithSize(string size)
        {
            _port.Size = size;
            return this;
        }

        public PortBuilder WithStatus(string status)
        {
            _port.Status = status;
            return this;
        }

        public PortBuilder WithBunkeringFacilities(bool hasBunkering)
        {
            _port.HasBunkeringFacilities = hasBunkering;
            return this;
        }

        public PortBuilder WithContainerFacilities(bool hasContainer)
        {
            _port.HasContainerFacilities = hasContainer;
            return this;
        }

        public PortBuilder WithBulkFacilities(bool hasBulk)
        {
            _port.HasBulkFacilities = hasBulk;
            return this;
        }

        public PortBuilder WithLiquidFacilities(bool hasLiquid)
        {
            _port.HasLiquidFacilities = hasLiquid;
            return this;
        }

        public PortBuilder WithRoRoFacilities(bool hasRoRo)
        {
            _port.HasRoRoFacilities = hasRoRo;
            return this;
        }

        public PortBuilder WithPassengerFacilities(bool hasPassenger)
        {
            _port.HasPassengerFacilities = hasPassenger;
            return this;
        }

        public PortBuilder WithRepairFacilities(bool hasRepair)
        {
            _port.HasRepairFacilities = hasRepair;
            return this;
        }

        public PortBuilder With24HourOperation(bool is24Hours)
        {
            _port.Is24Hours = is24Hours;
            return this;
        }

        public PortBuilder WithIceFree(bool isIceFree)
        {
            _port.IsIceFree = isIceFree;
            return this;
        }

        public PortBuilder WithCity(string city)
        {
            _port.City = city;
            return this;
        }

        public PortBuilder WithState(string state)
        {
            _port.State = state;
            return this;
        }

        public PortBuilder WithAlternativeName(string alternativeName)
        {
            _port.AlternativeName = alternativeName;
            return this;
        }

        public PortBuilder WithCoordinates(decimal latitude, decimal longitude)
        {
            _port.Latitude = latitude;
            _port.Longitude = longitude;
            return this;
        }

        public PortBuilder WithTimeZone(string timeZone)
        {
            _port.TimeZone = timeZone;
            return this;
        }

        public PortBuilder WithMaxDraft(decimal maxDraft)
        {
            _port.MaxDraft = maxDraft;
            return this;
        }

        public PortBuilder WithMaxVesselLength(decimal maxLength)
        {
            _port.MaxVesselLength = maxLength;
            return this;
        }

        public PortBuilder WithMaxVesselBeam(decimal maxBeam)
        {
            _port.MaxVesselBeam = maxBeam;
            return this;
        }

        public PortBuilder WithMaxDWT(decimal maxDWT)
        {
            _port.MaxDWT = maxDWT;
            return this;
        }

        public PortBuilder WithNumberOfBerths(int numberOfBerths)
        {
            _port.NumberOfBerths = numberOfBerths;
            return this;
        }

        public PortBuilder WithNumberOfTerminals(int numberOfTerminals)
        {
            _port.NumberOfTerminals = numberOfTerminals;
            return this;
        }

        public PortBuilder WithPortAuthority(string portAuthority)
        {
            _port.PortAuthority = portAuthority;
            return this;
        }

        public PortBuilder WithContactPhone(string contactPhone)
        {
            _port.ContactPhone = contactPhone;
            return this;
        }

        public PortBuilder WithContactEmail(string contactEmail)
        {
            _port.ContactEmail = contactEmail;
            return this;
        }

        public PortBuilder WithWebsite(string website)
        {
            _port.Website = website;
            return this;
        }

        public PortBuilder WithAverageWaitingTime(decimal waitingTimeHours)
        {
            _port.AverageWaitingTimeHours = waitingTimeHours;
            return this;
        }

        public PortBuilder WithAverageTurnaroundTime(decimal turnaroundTimeHours)
        {
            _port.AverageTurnaroundTimeHours = turnaroundTimeHours;
            return this;
        }

        public PortBuilder WithAnnualCargoThroughput(decimal throughputTEU)
        {
            _port.AnnualCargoThroughputTEU = throughputTEU;
            return this;
        }

        public PortBuilder WithAnnualVesselCalls(int vesselCalls)
        {
            _port.AnnualVesselCalls = vesselCalls;
            return this;
        }

        public PortBuilder WithNotes(string notes)
        {
            _port.Notes = notes;
            return this;
        }

        // Convenience methods for common scenarios
        public PortBuilder AsMajorSeaport()
        {
            return WithPortType("Seaport")
                   .WithSize("Major")
                   .WithStatus("Active")
                   .WithBunkeringFacilities(true)
                   .WithContainerFacilities(true)
                   .WithBulkFacilities(true)
                   .WithLiquidFacilities(true)
                   .With24HourOperation(true)
                   .WithIceFree(true);
        }

        public PortBuilder AsSmallRiverPort()
        {
            return WithPortType("River Port")
                   .WithSize("Small")
                   .WithStatus("Active")
                   .WithBunkeringFacilities(false)
                   .WithContainerFacilities(false)
                   .WithBulkFacilities(true)
                   .WithLiquidFacilities(false)
                   .With24HourOperation(false)
                   .WithIceFree(false);
        }

        public PortBuilder AsInactivePort()
        {
            return WithStatus("Inactive")
                   .WithBunkeringFacilities(false)
                   .WithContainerFacilities(false)
                   .WithBulkFacilities(false)
                   .WithLiquidFacilities(false)
                   .With24HourOperation(false);
        }

        public PortBuilder AsGermanPort()
        {
            return WithCountry("Germany")
                   .WithCity("Hamburg")
                   .WithState("Hamburg")
                   .WithTimeZone("Europe/Berlin")
                   .WithCoordinates(53.5511m, 9.9937m);
        }

        public PortBuilder AsDutchPort()
        {
            return WithCountry("Netherlands")
                   .WithCity("Rotterdam")
                   .WithState("South Holland")
                   .WithTimeZone("Europe/Amsterdam")
                   .WithCoordinates(51.9244m, 4.4777m);
        }

        public PortBuilder AsUSPort()
        {
            return WithCountry("United States")
                   .WithState("New York")
                   .WithTimeZone("America/New_York")
                   .WithCoordinates(40.6892m, -74.0445m);
        }
    }
}
