using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bunker.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UNLOCODE = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AlternativeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TimeZone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PortType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaxDraft = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxVesselLength = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxVesselBeam = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxDWT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NumberOfBerths = table.Column<int>(type: "int", nullable: true),
                    NumberOfTerminals = table.Column<int>(type: "int", nullable: true),
                    HasContainerFacilities = table.Column<bool>(type: "bit", nullable: false),
                    HasBulkFacilities = table.Column<bool>(type: "bit", nullable: false),
                    HasLiquidFacilities = table.Column<bool>(type: "bit", nullable: false),
                    HasRoRoFacilities = table.Column<bool>(type: "bit", nullable: false),
                    HasPassengerFacilities = table.Column<bool>(type: "bit", nullable: false),
                    HasBunkeringFacilities = table.Column<bool>(type: "bit", nullable: false),
                    HasRepairFacilities = table.Column<bool>(type: "bit", nullable: false),
                    Is24Hours = table.Column<bool>(type: "bit", nullable: false),
                    IsIceFree = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PortAuthority = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AverageWaitingTimeHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AverageTurnaroundTimeHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AnnualCargoThroughputTEU = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AnnualVesselCalls = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vessels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IMO = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VesselType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Flag = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GrossTonnage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DeadweightTonnage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LengthOverall = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Beam = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Draft = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    YearBuilt = table.Column<int>(type: "int", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaxCrew = table.Column<int>(type: "int", nullable: true),
                    EnginePowerKW = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxSpeedKnots = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CallSign = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MMSI = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vessels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voyages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoyageNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VesselId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DeparturePortId = table.Column<int>(type: "int", nullable: true),
                    ArrivalPortId = table.Column<int>(type: "int", nullable: true),
                    ScheduledDeparture = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualDeparture = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScheduledArrival = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualArrival = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DistanceNauticalMiles = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EstimatedDurationHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ActualDurationHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AverageSpeedKnots = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxSpeedKnots = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FuelConsumptionMT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FuelCostUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalCostUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RevenueUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProfitLossUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CargoType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CargoWeightMT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CargoVolumeM3 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TEUCount = table.Column<int>(type: "int", nullable: true),
                    PassengerCount = table.Column<int>(type: "int", nullable: true),
                    Charterer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CargoOwner = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CharterType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CharterRateUSDPerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CharterDurationDays = table.Column<int>(type: "int", nullable: true),
                    WeatherConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeaState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WindSpeedKnots = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaveHeightMeters = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VisibilityNauticalMiles = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HasIncidents = table.Column<bool>(type: "bit", nullable: false),
                    IncidentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncidentSeverity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncidentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HasDelays = table.Column<bool>(type: "bit", nullable: false),
                    DelayReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DelayDurationHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DelayCostUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PortCallCount = table.Column<int>(type: "int", nullable: false),
                    BunkerOrderCount = table.Column<int>(type: "int", nullable: false),
                    TotalBunkerQuantityMT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalBunkerCostUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CaptainName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChiefEngineerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrewCount = table.Column<int>(type: "int", nullable: true),
                    IsInternational = table.Column<bool>(type: "bit", nullable: false),
                    CrossesEquator = table.Column<bool>(type: "bit", nullable: false),
                    CrossesDateLine = table.Column<bool>(type: "bit", nullable: false),
                    TimeZoneChanges = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voyages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voyages_Ports_ArrivalPortId",
                        column: x => x.ArrivalPortId,
                        principalTable: "Ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voyages_Ports_DeparturePortId",
                        column: x => x.DeparturePortId,
                        principalTable: "Ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voyages_Vessels_VesselId",
                        column: x => x.VesselId,
                        principalTable: "Vessels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PortCalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VesselId = table.Column<int>(type: "int", nullable: false),
                    PortId = table.Column<int>(type: "int", nullable: false),
                    VoyageId = table.Column<int>(type: "int", nullable: true),
                    PortCallNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduledArrival = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualArrival = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScheduledDeparture = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualDeparture = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArrivalDelayHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DepartureDelayHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalDurationHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BerthNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerminalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerminalOperator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BerthType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BerthLengthMeters = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BerthDraftMeters = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BerthWidthMeters = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsAnchorage = table.Column<bool>(type: "bit", nullable: false),
                    AnchorageArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PilotRequired = table.Column<bool>(type: "bit", nullable: false),
                    PilotAssigned = table.Column<bool>(type: "bit", nullable: false),
                    PilotName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PilotBoardingTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TugAssistanceRequired = table.Column<bool>(type: "bit", nullable: false),
                    TugCount = table.Column<int>(type: "int", nullable: true),
                    TugNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoOperations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoWeightMT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CargoVolumeM3 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ContainerCount = table.Column<int>(type: "int", nullable: true),
                    TEUCount = table.Column<int>(type: "int", nullable: true),
                    LoadingWeightMT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DischargingWeightMT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CargoHandlingRateMTPerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CargoHandlingStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CargoHandlingEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CargoHandlingDurationHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BunkeringRequired = table.Column<bool>(type: "bit", nullable: false),
                    BunkerQuantityMT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BunkerType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BunkerSupplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BunkerCostUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BunkeringStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BunkeringEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BunkeringDurationHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FreshWaterRequired = table.Column<bool>(type: "bit", nullable: false),
                    FreshWaterQuantityMT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FreshWaterCostUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProvisionsRequired = table.Column<bool>(type: "bit", nullable: false),
                    ProvisionsSupplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvisionsCostUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RepairsRequired = table.Column<bool>(type: "bit", nullable: false),
                    RepairType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepairDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepairSupplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepairCostUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RepairStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RepairEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RepairDurationHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CrewChangeRequired = table.Column<bool>(type: "bit", nullable: false),
                    CrewJoiningCount = table.Column<int>(type: "int", nullable: true),
                    CrewLeavingCount = table.Column<int>(type: "int", nullable: true),
                    CrewChangeCostUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InspectionRequired = table.Column<bool>(type: "bit", nullable: false),
                    InspectionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspectionAuthority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspectionResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InspectionCostUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CustomsClearanceRequired = table.Column<bool>(type: "bit", nullable: false),
                    CustomsClearanceStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomsClearanceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomsClearanceCostUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PortChargesUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PilotageCostUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TugCostUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BerthCostUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TerminalCostUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalPortCostUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WeatherConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeaState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WindSpeedKnots = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaveHeightMeters = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VisibilityNauticalMiles = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HasIncidents = table.Column<bool>(type: "bit", nullable: false),
                    IncidentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncidentSeverity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncidentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IncidentCostUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortCalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortCalls_Ports_PortId",
                        column: x => x.PortId,
                        principalTable: "Ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PortCalls_Vessels_VesselId",
                        column: x => x.VesselId,
                        principalTable: "Vessels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PortCalls_Voyages_VoyageId",
                        column: x => x.VoyageId,
                        principalTable: "Voyages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BunkerOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VesselId = table.Column<int>(type: "int", nullable: false),
                    PortId = table.Column<int>(type: "int", nullable: false),
                    VoyageId = table.Column<int>(type: "int", nullable: true),
                    PortCallId = table.Column<int>(type: "int", nullable: true),
                    OrderNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    QuantityMT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPriceUSDPerMT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalPriceUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LocalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LocalCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SupplierContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SupplierPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SupplierEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SupplierAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SupplierLicenseNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScheduledDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryDurationHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DeliveryMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BargeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BargeCapacityMT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BargeIMO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TruckCount = table.Column<int>(type: "int", nullable: true),
                    TruckLicensePlates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PipelineDelivery = table.Column<bool>(type: "bit", nullable: false),
                    PipelineLengthMeters = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DeliveryLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BerthNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerminalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnchorageArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualitySpecifications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DensityAt15C = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ViscosityAt50C = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SulfurContentPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FlashPointCelsius = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PourPointCelsius = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterContentPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SedimentContentPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AshContentPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CarbonResiduePercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VanadiumContentPPM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AluminumContentPPM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SiliconContentPPM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CertificateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CertificateIssuedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificateValidUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SampleTaken = table.Column<bool>(type: "bit", nullable: false),
                    SampleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SampleLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SampleSealedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SampleReceivedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SampleStorageLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceAmountUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TaxAmountUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountAmountUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FinalAmountUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DeliveryConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    QualityAcceptance = table.Column<bool>(type: "bit", nullable: false),
                    QualityIssues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisputeStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisputeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisputeResolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisputeResolutionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RefundAmountUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RefundDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EnvironmentalCompliance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMO2020Compliant = table.Column<bool>(type: "bit", nullable: false),
                    LowSulfurFuel = table.Column<bool>(type: "bit", nullable: false),
                    BioFuelBlend = table.Column<bool>(type: "bit", nullable: false),
                    BioFuelPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CarbonFootprintMTCO2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SustainabilityCertificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BunkerOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BunkerOrders_PortCalls_PortCallId",
                        column: x => x.PortCallId,
                        principalTable: "PortCalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BunkerOrders_Ports_PortId",
                        column: x => x.PortId,
                        principalTable: "Ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BunkerOrders_Vessels_VesselId",
                        column: x => x.VesselId,
                        principalTable: "Vessels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BunkerOrders_Voyages_VoyageId",
                        column: x => x.VoyageId,
                        principalTable: "Voyages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BunkerOrders_PortCallId",
                table: "BunkerOrders",
                column: "PortCallId");

            migrationBuilder.CreateIndex(
                name: "IX_BunkerOrders_PortId",
                table: "BunkerOrders",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_BunkerOrders_VesselId",
                table: "BunkerOrders",
                column: "VesselId");

            migrationBuilder.CreateIndex(
                name: "IX_BunkerOrders_VoyageId",
                table: "BunkerOrders",
                column: "VoyageId");

            migrationBuilder.CreateIndex(
                name: "IX_PortCalls_PortId",
                table: "PortCalls",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_PortCalls_VesselId",
                table: "PortCalls",
                column: "VesselId");

            migrationBuilder.CreateIndex(
                name: "IX_PortCalls_VoyageId",
                table: "PortCalls",
                column: "VoyageId");

            migrationBuilder.CreateIndex(
                name: "IX_Voyages_ArrivalPortId",
                table: "Voyages",
                column: "ArrivalPortId");

            migrationBuilder.CreateIndex(
                name: "IX_Voyages_DeparturePortId",
                table: "Voyages",
                column: "DeparturePortId");

            migrationBuilder.CreateIndex(
                name: "IX_Voyages_VesselId",
                table: "Voyages",
                column: "VesselId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BunkerOrders");

            migrationBuilder.DropTable(
                name: "PortCalls");

            migrationBuilder.DropTable(
                name: "Voyages");

            migrationBuilder.DropTable(
                name: "Ports");

            migrationBuilder.DropTable(
                name: "Vessels");
        }
    }
}
