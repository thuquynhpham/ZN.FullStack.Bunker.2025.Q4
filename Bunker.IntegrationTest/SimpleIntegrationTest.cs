using System.Net;
using System.Text.Json;
using Bunker.Domain.DBI;
using Bunker.Domain.Models;
using Bunker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Bunker.IntegrationTest;

[TestFixture]
public class SimpleIntegrationTest
{
    private BunkerDbContext _context = null!;
    private string _databaseName = null!;

    [SetUp]
    public void SetUp()
    {
        // Create a unique database name for each test
        _databaseName = $"BunkerTestDb_{Guid.NewGuid()}";
        
        var options = new DbContextOptionsBuilder<BunkerDbContext>()
            .UseInMemoryDatabase(databaseName: _databaseName)
            .Options;

        _context = new BunkerDbContext(options);
        
        // Ensure clean database
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
        
        SeedTestData();
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up the database
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    [Test]
    public void PortRepository_ShouldReturnAllPorts_WhenNoFiltersApplied()
    {
        // Arrange
        var repository = new PortRepository(_context);

        // Act
        var ports = repository.GetAll().ToList();

        // Assert
        Assert.That(ports, Is.Not.Null);
        Assert.That(ports.Count, Is.EqualTo(2));
        Assert.That(ports.Any(p => p.Name == "Port of New York"), Is.True);
        Assert.That(ports.Any(p => p.Name == "Port of Los Angeles"), Is.True);
    }

    [Test]
    public void PortRepository_ShouldReturnFilteredPorts_WhenCountryFilterApplied()
    {
        // Arrange
        var repository = new PortRepository(_context);

        // Act
        var ports = repository.GetAll()
            .Where(p => p.Country == "United States")
            .ToList();

        // Assert
        Assert.That(ports, Is.Not.Null);
        Assert.That(ports.Count, Is.EqualTo(2));
        Assert.That(ports.All(p => p.Country == "United States"), Is.True);
    }

    [Test]
    public async Task PortRepository_ShouldReturnPortById_WhenValidIdProvided()
    {
        // Arrange
        var repository = new PortRepository(_context);

        // Act
        var port = await repository.GetByIdAsync(1);

        // Assert
        Assert.That(port, Is.Not.Null);
        Assert.That(port.Id, Is.EqualTo(1));
        Assert.That(port.Name, Is.EqualTo("Port of New York"));
        Assert.That(port.Country, Is.EqualTo("United States"));
    }

    [Test]
    public async Task PortRepository_ShouldReturnNull_WhenInvalidIdProvided()
    {
        // Arrange
        var repository = new PortRepository(_context);

        // Act
        var port = await repository.GetByIdAsync(999);

        // Assert
        Assert.That(port, Is.Null);
    }

    [Test]
    public void PortCallRepository_ShouldReturnAllPortCalls_WhenNoFiltersApplied()
    {
        // Arrange
        var repository = new PortCallRepository(_context);

        // Act
        var portCalls = repository.GetAll().ToList();

        // Assert
        Assert.That(portCalls, Is.Not.Null);
        Assert.That(portCalls.Count, Is.EqualTo(2));
        Assert.That(portCalls.Any(pc => pc.PortCallNumber == "PC001"), Is.True);
        Assert.That(portCalls.Any(pc => pc.PortCallNumber == "PC002"), Is.True);
    }

    [Test]
    public void PortCallRepository_ShouldReturnFilteredPortCalls_WhenVesselIdFilterApplied()
    {
        // Arrange
        var repository = new PortCallRepository(_context);

        // Act
        var portCalls = repository.GetAll()
            .Where(pc => pc.VesselId == 1)
            .ToList();

        // Assert
        Assert.That(portCalls, Is.Not.Null);
        Assert.That(portCalls.Count, Is.EqualTo(1));
        Assert.That(portCalls.First().VesselId, Is.EqualTo(1));
        Assert.That(portCalls.First().PortCallNumber, Is.EqualTo("PC001"));
    }

    [Test]
    public async Task PortCallRepository_ShouldReturnPortCallById_WhenValidIdProvided()
    {
        // Arrange
        var repository = new PortCallRepository(_context);

        // Act
        var portCall = await repository.GetByIdAsync(1);

        // Assert
        Assert.That(portCall, Is.Not.Null);
        Assert.That(portCall.Id, Is.EqualTo(1));
        Assert.That(portCall.PortCallNumber, Is.EqualTo("PC001"));
        Assert.That(portCall.Status, Is.EqualTo("Scheduled"));
        Assert.That(portCall.VesselId, Is.EqualTo(1));
        Assert.That(portCall.PortId, Is.EqualTo(1));
    }

    [Test]
    public async Task PortCallRepository_ShouldReturnNull_WhenInvalidIdProvided()
    {
        // Arrange
        var repository = new PortCallRepository(_context);

        // Act
        var portCall = await repository.GetByIdAsync(999);

        // Assert
        Assert.That(portCall, Is.Null);
    }

    [Test]
    public async Task PortCallRepository_ShouldCreateNewPortCall_WhenValidDataProvided()
    {
        // Arrange
        var repository = new PortCallRepository(_context);
        var newPortCall = new PortCall
        {
            VesselId = 1,
            PortId = 2,
            VoyageId = 1,
            PortCallNumber = "PC003",
            Status = "Scheduled",
            Purpose = "Cargo Operations",
            CallType = "Scheduled",
            ScheduledArrival = DateTime.UtcNow.AddDays(5),
            ScheduledDeparture = DateTime.UtcNow.AddDays(7),
            BerthNumber = "Berth 7",
            TerminalName = "Container Terminal B",
            CargoType = "Container",
            BunkeringRequired = false,
            TotalPortCostUSD = 60000,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "Test"
        };

        // Act
        var result = await repository.AddAsync(newPortCall);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.GreaterThan(0));
        Assert.That(result.PortCallNumber, Is.EqualTo("PC003"));

        // Verify it was saved to the database
        var savedPortCall = await repository.GetByIdAsync(result.Id);
        Assert.That(savedPortCall, Is.Not.Null);
        Assert.That(savedPortCall.PortCallNumber, Is.EqualTo("PC003"));
    }

    private void SeedTestData()
    {
        // Clear all existing data to ensure clean state
        _context.PortCalls.RemoveRange(_context.PortCalls);
        _context.Voyages.RemoveRange(_context.Voyages);
        _context.Ports.RemoveRange(_context.Ports);
        _context.Vessels.RemoveRange(_context.Vessels);
        _context.SaveChanges();
        
        // Add test vessels
        var vessels = new[]
        {
            new Vessel
            {
                Id = 1,
                Name = "Test Vessel 1",
                IMO = "IMO1234567",
                MMSI = "MMSI123456789",
                CallSign = "TEST1",
                VesselType = "Container Ship",
                Flag = "Liberia",
                GrossTonnage = 50000,
                DeadweightTonnage = 60000,
                LengthOverall = 300,
                Beam = 40,
                Draft = 15,
                YearBuilt = 2020,
                Status = "Active",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Test"
            },
            new Vessel
            {
                Id = 2,
                Name = "Test Vessel 2",
                IMO = "IMO2345678",
                MMSI = "MMSI234567890",
                CallSign = "TEST2",
                VesselType = "Bulk Carrier",
                Flag = "Panama",
                GrossTonnage = 80000,
                DeadweightTonnage = 100000,
                LengthOverall = 250,
                Beam = 35,
                Draft = 18,
                YearBuilt = 2019,
                Status = "Active",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Test"
            }
        };

        _context.Vessels.AddRange(vessels);

        // Add test ports
        var ports = new[]
        {
            new Port
            {
                Id = 1,
                UNLOCODE = "USNYC",
                Name = "Port of New York",
                Country = "United States",
                City = "New York",
                State = "NY",
                Latitude = 40.6892m,
                Longitude = -74.0445m,
                TimeZone = "America/New_York",
                PortType = "Seaport",
                Size = "Major",
                Status = "Active",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Test"
            },
            new Port
            {
                Id = 2,
                UNLOCODE = "USLAX",
                Name = "Port of Los Angeles",
                Country = "United States",
                City = "Los Angeles",
                State = "CA",
                Latitude = 33.7175m,
                Longitude = -118.2728m,
                TimeZone = "America/Los_Angeles",
                PortType = "Seaport",
                Size = "Major",
                Status = "Active",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Test"
            }
        };

        _context.Ports.AddRange(ports);

        // Add test voyages
        var voyages = new[]
        {
            new Voyage
            {
                Id = 1,
                VoyageNumber = "V001",
                VesselId = 1,
                DeparturePortId = 1,
                ArrivalPortId = 2,
                Status = "In Progress",
                ScheduledDeparture = DateTime.UtcNow.AddDays(-5),
                ActualDeparture = DateTime.UtcNow.AddDays(-5).AddHours(2),
                ScheduledArrival = DateTime.UtcNow.AddDays(2),
                ActualArrival = null,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Test"
            }
        };

        _context.Voyages.AddRange(voyages);

        // Add test port calls
        var portCalls = new[]
        {
            new PortCall
            {
                Id = 1,
                VesselId = 1,
                PortId = 1,
                VoyageId = 1,
                PortCallNumber = "PC001",
                Status = "Scheduled",
                Purpose = "Cargo Operations",
                CallType = "Scheduled",
                ScheduledArrival = DateTime.UtcNow.AddDays(1),
                ScheduledDeparture = DateTime.UtcNow.AddDays(3),
                BerthNumber = "Berth 5",
                TerminalName = "Container Terminal A",
                CargoType = "Container",
                BunkeringRequired = true,
                BunkerQuantityMT = 500,
                BunkerType = "MGO",
                TotalPortCostUSD = 50000,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Test"
            },
            new PortCall
            {
                Id = 2,
                VesselId = 2,
                PortId = 2,
                PortCallNumber = "PC002",
                Status = "Completed",
                Purpose = "Bunkering",
                CallType = "Bunkering",
                ScheduledArrival = DateTime.UtcNow.AddDays(-2),
                ActualArrival = DateTime.UtcNow.AddDays(-2).AddHours(1),
                ScheduledDeparture = DateTime.UtcNow.AddDays(-1),
                ActualDeparture = DateTime.UtcNow.AddDays(-1).AddHours(2),
                BerthNumber = "Berth 3",
                TerminalName = "Bunker Terminal",
                CargoType = "Bulk",
                BunkeringRequired = true,
                BunkerQuantityMT = 800,
                BunkerType = "HFO",
                TotalPortCostUSD = 75000,
                CreatedAt = DateTime.UtcNow.AddDays(-3),
                CreatedBy = "Test"
            }
        };

        _context.PortCalls.AddRange(portCalls);
        _context.SaveChanges();
    }
}
