using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bunker.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Deadweight",
                table: "Vessels",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Length",
                table: "Vessels",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NetTonnage",
                table: "Vessels",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Width",
                table: "Vessels",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Vessels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Deadweight", "Length", "NetTonnage", "Width" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Vessels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Deadweight", "Length", "NetTonnage", "Width" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Vessels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Deadweight", "Length", "NetTonnage", "Width" },
                values: new object[] { null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deadweight",
                table: "Vessels");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Vessels");

            migrationBuilder.DropColumn(
                name: "NetTonnage",
                table: "Vessels");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Vessels");
        }
    }
}
