using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bunker.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ports",
                columns: new[] { "Id", "AlternativeName", "AnnualCargoThroughputTEU", "AnnualVesselCalls", "AverageTurnaroundTimeHours", "AverageWaitingTimeHours", "City", "ContactEmail", "ContactPhone", "Country", "CreatedAt", "CreatedBy", "HasBulkFacilities", "HasBunkeringFacilities", "HasContainerFacilities", "HasLiquidFacilities", "HasPassengerFacilities", "HasRepairFacilities", "HasRoRoFacilities", "Is24Hours", "IsIceFree", "Latitude", "Longitude", "MaxDWT", "MaxDraft", "MaxVesselBeam", "MaxVesselLength", "Name", "Notes", "NumberOfBerths", "NumberOfTerminals", "PortAuthority", "PortType", "Size", "State", "Status", "TimeZone", "UNLOCODE", "UpdatedAt", "UpdatedBy", "Website" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, "Singapore", null, null, "Singapore", new DateTime(2025, 10, 22, 20, 17, 49, 58, DateTimeKind.Utc).AddTicks(2244), "System", false, true, true, false, false, false, false, true, true, 1.2966m, 103.7764m, null, 16m, 60m, 400m, "Port of Singapore", null, null, null, null, "Container Port", "Major", null, "Active", "Asia/Singapore", "SGSIN", null, null, null },
                    { 2, null, null, null, null, null, "Rotterdam", null, null, "Netherlands", new DateTime(2025, 10, 22, 20, 17, 49, 58, DateTimeKind.Utc).AddTicks(2653), "System", false, true, true, false, false, false, false, true, true, 51.9225m, 4.4792m, null, 20m, 60m, 400m, "Port of Rotterdam", null, null, null, null, "Container Port", "Major", null, "Active", "Europe/Amsterdam", "NLRTM", null, null, null },
                    { 3, null, null, null, null, null, "Los Angeles", null, null, "United States", new DateTime(2025, 10, 22, 20, 17, 49, 58, DateTimeKind.Utc).AddTicks(2658), "System", false, true, true, false, false, false, false, true, true, 33.7175m, -118.2728m, null, 15m, 60m, 400m, "Port of Los Angeles", null, null, null, null, "Container Port", "Major", null, "Active", "America/Los_Angeles", "USLAX", null, null, null },
                    { 4, null, null, null, null, null, "Hamburg", null, null, "Germany", new DateTime(2025, 10, 22, 20, 17, 49, 58, DateTimeKind.Utc).AddTicks(2662), "System", false, true, true, false, false, false, false, true, true, 53.5511m, 9.9937m, null, 14m, 50m, 350m, "Port of Hamburg", null, null, null, null, "Container Port", "Major", null, "Active", "Europe/Berlin", "DEHAM", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Vessels",
                columns: new[] { "Id", "Beam", "CallSign", "CreatedAt", "CreatedBy", "DeadweightTonnage", "Draft", "EnginePowerKW", "Flag", "GrossTonnage", "IMO", "LengthOverall", "MMSI", "MaxCrew", "MaxSpeedKnots", "Name", "Notes", "Owner", "Status", "UpdatedAt", "UpdatedBy", "VesselType", "YearBuilt" },
                values: new object[,]
                {
                    { 1, 32m, "ABCD123", new DateTime(2025, 10, 22, 20, 17, 49, 56, DateTimeKind.Utc).AddTicks(7298), "System", 60000m, 12m, 15000m, "Panama", 50000m, "1234567", 200m, "123456789", 25, 22m, "MV Atlantic Star", null, "Atlantic Shipping Ltd", "Active", null, null, "Container Ship", 2015 },
                    { 2, 40m, "EFGH456", new DateTime(2025, 10, 22, 20, 17, 49, 56, DateTimeKind.Utc).AddTicks(7747), "System", 85000m, 15m, 20000m, "Liberia", 75000m, "2345678", 250m, "234567890", 30, 18m, "MV Pacific Explorer", null, "Pacific Maritime Corp", "Active", null, null, "Bulk Carrier", 2018 },
                    { 3, 50m, "IJKL789", new DateTime(2025, 10, 22, 20, 17, 49, 56, DateTimeKind.Utc).AddTicks(7753), "System", 120000m, 18m, 25000m, "Marshall Islands", 100000m, "3456789", 300m, "345678901", 35, 16m, "MV Indian Ocean", null, "Ocean Transport Ltd", "Active", null, null, "Tanker", 2020 }
                });

            migrationBuilder.InsertData(
                table: "Voyages",
                columns: new[] { "Id", "ActualArrival", "ActualDeparture", "ActualDurationHours", "ArrivalPortId", "AverageSpeedKnots", "BunkerOrderCount", "CaptainName", "CargoOwner", "CargoType", "CargoVolumeM3", "CargoWeightMT", "CharterDurationDays", "CharterRateUSDPerDay", "CharterType", "Charterer", "ChiefEngineerName", "CreatedAt", "CreatedBy", "CrewCount", "CrossesDateLine", "CrossesEquator", "DelayCostUSD", "DelayDurationHours", "DelayReason", "DeparturePortId", "DistanceNauticalMiles", "EstimatedDurationHours", "FuelConsumptionMT", "FuelCostUSD", "HasDelays", "HasIncidents", "IncidentDate", "IncidentDescription", "IncidentSeverity", "IsInternational", "MaxSpeedKnots", "Notes", "PassengerCount", "PortCallCount", "ProfitLossUSD", "RevenueUSD", "ScheduledArrival", "ScheduledDeparture", "SeaState", "Status", "TEUCount", "TimeZoneChanges", "TotalBunkerCostUSD", "TotalBunkerQuantityMT", "TotalCostUSD", "UpdatedAt", "UpdatedBy", "VesselId", "VisibilityNauticalMiles", "VoyageNumber", "WaveHeightMeters", "WeatherConditions", "WindSpeedKnots" },
                values: new object[,]
                {
                    { 1, null, null, null, 2, null, 0, null, null, "Containers", null, 50000m, null, null, null, null, null, new DateTime(2025, 10, 22, 20, 17, 49, 58, DateTimeKind.Utc).AddTicks(9769), "System", null, false, false, null, null, null, 1, 8000m, null, null, null, false, false, null, null, null, true, null, null, null, 0, null, null, new DateTime(2025, 11, 11, 20, 17, 49, 58, DateTimeKind.Utc).AddTicks(8248), new DateTime(2025, 10, 29, 20, 17, 49, 58, DateTimeKind.Utc).AddTicks(7854), null, "Planned", null, null, null, null, null, null, null, 1, null, "V001-2024", null, null, null },
                    { 2, null, null, null, 3, null, 0, null, null, "Bulk Cargo", null, 75000m, null, null, null, null, null, new DateTime(2025, 10, 22, 20, 17, 49, 59, DateTimeKind.Utc).AddTicks(177), "System", null, false, false, null, null, null, 2, 6000m, null, null, null, false, false, null, null, null, true, null, null, null, 0, null, null, new DateTime(2025, 11, 16, 20, 17, 49, 59, DateTimeKind.Utc).AddTicks(174), new DateTime(2025, 11, 1, 20, 17, 49, 59, DateTimeKind.Utc).AddTicks(173), null, "Planned", null, null, null, null, null, null, null, 2, null, "V002-2024", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "PortCalls",
                columns: new[] { "Id", "ActualArrival", "ActualDeparture", "AnchorageArea", "ArrivalDelayHours", "BerthCostUSD", "BerthDraftMeters", "BerthLengthMeters", "BerthNumber", "BerthType", "BerthWidthMeters", "BunkerCostUSD", "BunkerQuantityMT", "BunkerSupplier", "BunkerType", "BunkeringDurationHours", "BunkeringEndTime", "BunkeringRequired", "BunkeringStartTime", "CallType", "CargoHandlingDurationHours", "CargoHandlingEndTime", "CargoHandlingRateMTPerHour", "CargoHandlingStartTime", "CargoOperations", "CargoType", "CargoVolumeM3", "CargoWeightMT", "ContainerCount", "CreatedAt", "CreatedBy", "CrewChangeCostUSD", "CrewChangeRequired", "CrewJoiningCount", "CrewLeavingCount", "CustomsClearanceCostUSD", "CustomsClearanceDate", "CustomsClearanceRequired", "CustomsClearanceStatus", "DepartureDelayHours", "DischargingWeightMT", "FreshWaterCostUSD", "FreshWaterQuantityMT", "FreshWaterRequired", "HasIncidents", "IncidentCostUSD", "IncidentDate", "IncidentDescription", "IncidentSeverity", "InspectionAuthority", "InspectionCostUSD", "InspectionDate", "InspectionRequired", "InspectionResult", "InspectionType", "IsAnchorage", "LoadingWeightMT", "Notes", "PilotAssigned", "PilotBoardingTime", "PilotName", "PilotRequired", "PilotageCostUSD", "PortCallNumber", "PortChargesUSD", "PortId", "ProvisionsCostUSD", "ProvisionsRequired", "ProvisionsSupplier", "Purpose", "RepairCostUSD", "RepairDescription", "RepairDurationHours", "RepairEndTime", "RepairStartTime", "RepairSupplier", "RepairType", "RepairsRequired", "ScheduledArrival", "ScheduledDeparture", "SeaState", "Status", "TEUCount", "TerminalCostUSD", "TerminalName", "TerminalOperator", "TotalDurationHours", "TotalPortCostUSD", "TugAssistanceRequired", "TugCostUSD", "TugCount", "TugNames", "UpdatedAt", "UpdatedBy", "VesselId", "VisibilityNauticalMiles", "VoyageId", "WaveHeightMeters", "WeatherConditions", "WindSpeedKnots" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, null, null, null, null, null, null, "Container Loading", null, null, null, null, new DateTime(2025, 10, 22, 20, 17, 49, 59, DateTimeKind.Utc).AddTicks(6332), "System", null, false, null, null, null, null, false, null, null, null, null, null, false, false, null, null, null, null, null, null, null, false, null, null, false, null, null, false, null, null, false, null, "PC001-2024", null, 1, null, false, null, "Loading", null, null, null, null, null, null, null, false, new DateTime(2025, 10, 29, 20, 17, 49, 59, DateTimeKind.Utc).AddTicks(4726), new DateTime(2025, 10, 31, 20, 17, 49, 59, DateTimeKind.Utc).AddTicks(4982), null, "Scheduled", null, null, null, null, null, null, false, null, null, null, null, null, 1, null, 1, null, null, null },
                    { 2, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, null, null, null, null, null, null, "Bulk Cargo Loading", null, null, null, null, new DateTime(2025, 10, 22, 20, 17, 49, 59, DateTimeKind.Utc).AddTicks(6744), "System", null, false, null, null, null, null, false, null, null, null, null, null, false, false, null, null, null, null, null, null, null, false, null, null, false, null, null, false, null, null, false, null, "PC002-2024", null, 2, null, false, null, "Loading", null, null, null, null, null, null, null, false, new DateTime(2025, 11, 1, 20, 17, 49, 59, DateTimeKind.Utc).AddTicks(6740), new DateTime(2025, 11, 3, 20, 17, 49, 59, DateTimeKind.Utc).AddTicks(6742), null, "Scheduled", null, null, null, null, null, null, false, null, null, null, null, null, 2, null, 2, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "BunkerOrders",
                columns: new[] { "Id", "ActualDeliveryDate", "AluminumContentPPM", "AnchorageArea", "ApprovedDate", "AshContentPercent", "BargeCapacityMT", "BargeIMO", "BargeName", "BerthNumber", "BioFuelBlend", "BioFuelPercentage", "CarbonFootprintMTCO2", "CarbonResiduePercent", "CertificateDate", "CertificateIssuedBy", "CertificateNumber", "CertificateValidUntil", "CreatedAt", "CreatedBy", "Currency", "DeliveryConfirmation", "DeliveryDurationHours", "DeliveryEndTime", "DeliveryLocation", "DeliveryMethod", "DeliveryStartTime", "DensityAt15C", "DiscountAmountUSD", "DisputeDescription", "DisputeResolution", "DisputeResolutionDate", "DisputeStatus", "EnvironmentalCompliance", "ExchangeRate", "FinalAmountUSD", "FlashPointCelsius", "FuelType", "IMO2020Compliant", "InvoiceAmountUSD", "InvoiceDate", "InvoiceNumber", "LocalCurrency", "LocalPrice", "LowSulfurFuel", "Notes", "OrderNumber", "PaymentDate", "PaymentDueDate", "PaymentMethod", "PaymentStatus", "PaymentTerms", "PipelineDelivery", "PipelineLengthMeters", "PortCallId", "PortId", "PourPointCelsius", "QualityAcceptance", "QualityIssues", "QualitySpecifications", "QuantityMT", "RefundAmountUSD", "RefundDate", "RequestedDate", "SampleDate", "SampleLocation", "SampleReceivedBy", "SampleSealedBy", "SampleStorageLocation", "SampleTaken", "ScheduledDeliveryDate", "SedimentContentPercent", "SiliconContentPPM", "Status", "SulfurContentPercent", "SupplierAddress", "SupplierContactPerson", "SupplierEmail", "SupplierLicenseNumber", "SupplierName", "SupplierPhone", "SustainabilityCertificate", "TaxAmountUSD", "TerminalName", "TotalPriceUSD", "TruckCount", "TruckLicensePlates", "UnitPriceUSDPerMT", "UpdatedAt", "UpdatedBy", "VanadiumContentPPM", "VesselId", "ViscosityAt50C", "VoyageId", "WaterContentPercent" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, null, null, null, null, false, null, null, null, null, null, null, null, new DateTime(2025, 10, 22, 20, 17, 49, 60, DateTimeKind.Utc).AddTicks(4437), "System", "USD", false, null, null, null, "Barge", null, null, null, null, null, null, null, null, null, null, null, "MGO", true, null, null, null, null, null, false, null, "BO001-2024", null, null, null, null, null, false, null, 1, 1, null, false, null, null, 500m, null, null, new DateTime(2025, 10, 22, 20, 17, 49, 60, DateTimeKind.Utc).AddTicks(3083), null, null, null, null, null, false, new DateTime(2025, 10, 30, 20, 17, 49, 60, DateTimeKind.Utc).AddTicks(3342), null, null, "Requested", null, null, null, null, null, "Singapore Fuel Co", null, null, null, null, 325000m, null, null, 650m, null, null, null, 1, null, 1, null },
                    { 2, null, null, null, null, null, null, null, null, null, false, null, null, null, null, null, null, null, new DateTime(2025, 10, 22, 20, 17, 49, 60, DateTimeKind.Utc).AddTicks(4840), "System", "USD", false, null, null, null, "Barge", null, null, null, null, null, null, null, null, null, null, null, "IFO 380", true, null, null, null, null, null, false, null, "BO002-2024", null, null, null, null, null, false, null, 2, 2, null, false, null, null, 1000m, null, null, new DateTime(2025, 10, 22, 20, 17, 49, 60, DateTimeKind.Utc).AddTicks(4837), null, null, null, null, null, false, new DateTime(2025, 11, 2, 20, 17, 49, 60, DateTimeKind.Utc).AddTicks(4838), null, null, "Requested", null, null, null, null, null, "Rotterdam Bunker Services", null, null, null, null, 450000m, null, null, 450m, null, null, null, 2, null, 2, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BunkerOrders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BunkerOrders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ports",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vessels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PortCalls",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PortCalls",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Voyages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Voyages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ports",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ports",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vessels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vessels",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
