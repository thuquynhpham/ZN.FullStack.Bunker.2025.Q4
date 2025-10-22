using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bunker.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDateTimeNowFromSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BunkerOrders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "RequestedDate", "ScheduledDeliveryDate" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "BunkerOrders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "RequestedDate", "ScheduledDeliveryDate" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PortCalls",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ScheduledArrival", "ScheduledDeparture" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PortCalls",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ScheduledArrival", "ScheduledDeparture" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Ports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Ports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Ports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Ports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Vessels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Vessels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Vessels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Voyages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ScheduledArrival", "ScheduledDeparture" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Voyages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ScheduledArrival", "ScheduledDeparture" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BunkerOrders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "RequestedDate", "ScheduledDeliveryDate" },
                values: new object[] { new DateTime(2025, 10, 22, 20, 17, 49, 60, DateTimeKind.Utc).AddTicks(4437), new DateTime(2025, 10, 22, 20, 17, 49, 60, DateTimeKind.Utc).AddTicks(3083), new DateTime(2025, 10, 30, 20, 17, 49, 60, DateTimeKind.Utc).AddTicks(3342) });

            migrationBuilder.UpdateData(
                table: "BunkerOrders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "RequestedDate", "ScheduledDeliveryDate" },
                values: new object[] { new DateTime(2025, 10, 22, 20, 17, 49, 60, DateTimeKind.Utc).AddTicks(4840), new DateTime(2025, 10, 22, 20, 17, 49, 60, DateTimeKind.Utc).AddTicks(4837), new DateTime(2025, 11, 2, 20, 17, 49, 60, DateTimeKind.Utc).AddTicks(4838) });

            migrationBuilder.UpdateData(
                table: "PortCalls",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ScheduledArrival", "ScheduledDeparture" },
                values: new object[] { new DateTime(2025, 10, 22, 20, 17, 49, 59, DateTimeKind.Utc).AddTicks(6332), new DateTime(2025, 10, 29, 20, 17, 49, 59, DateTimeKind.Utc).AddTicks(4726), new DateTime(2025, 10, 31, 20, 17, 49, 59, DateTimeKind.Utc).AddTicks(4982) });

            migrationBuilder.UpdateData(
                table: "PortCalls",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ScheduledArrival", "ScheduledDeparture" },
                values: new object[] { new DateTime(2025, 10, 22, 20, 17, 49, 59, DateTimeKind.Utc).AddTicks(6744), new DateTime(2025, 11, 1, 20, 17, 49, 59, DateTimeKind.Utc).AddTicks(6740), new DateTime(2025, 11, 3, 20, 17, 49, 59, DateTimeKind.Utc).AddTicks(6742) });

            migrationBuilder.UpdateData(
                table: "Ports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 20, 17, 49, 58, DateTimeKind.Utc).AddTicks(2244));

            migrationBuilder.UpdateData(
                table: "Ports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 20, 17, 49, 58, DateTimeKind.Utc).AddTicks(2653));

            migrationBuilder.UpdateData(
                table: "Ports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 20, 17, 49, 58, DateTimeKind.Utc).AddTicks(2658));

            migrationBuilder.UpdateData(
                table: "Ports",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 20, 17, 49, 58, DateTimeKind.Utc).AddTicks(2662));

            migrationBuilder.UpdateData(
                table: "Vessels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 20, 17, 49, 56, DateTimeKind.Utc).AddTicks(7298));

            migrationBuilder.UpdateData(
                table: "Vessels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 20, 17, 49, 56, DateTimeKind.Utc).AddTicks(7747));

            migrationBuilder.UpdateData(
                table: "Vessels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 20, 17, 49, 56, DateTimeKind.Utc).AddTicks(7753));

            migrationBuilder.UpdateData(
                table: "Voyages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ScheduledArrival", "ScheduledDeparture" },
                values: new object[] { new DateTime(2025, 10, 22, 20, 17, 49, 58, DateTimeKind.Utc).AddTicks(9769), new DateTime(2025, 11, 11, 20, 17, 49, 58, DateTimeKind.Utc).AddTicks(8248), new DateTime(2025, 10, 29, 20, 17, 49, 58, DateTimeKind.Utc).AddTicks(7854) });

            migrationBuilder.UpdateData(
                table: "Voyages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ScheduledArrival", "ScheduledDeparture" },
                values: new object[] { new DateTime(2025, 10, 22, 20, 17, 49, 59, DateTimeKind.Utc).AddTicks(177), new DateTime(2025, 11, 16, 20, 17, 49, 59, DateTimeKind.Utc).AddTicks(174), new DateTime(2025, 11, 1, 20, 17, 49, 59, DateTimeKind.Utc).AddTicks(173) });
        }
    }
}
