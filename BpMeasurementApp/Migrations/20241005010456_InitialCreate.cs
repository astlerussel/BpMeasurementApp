using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BpMeasurementApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Systolic = table.Column<int>(type: "int", nullable: false),
                    Diastolic = table.Column<int>(type: "int", nullable: false),
                    MeasurementDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Id", "Diastolic", "MeasurementDate", "Systolic" },
                values: new object[,]
                {
                    { 1, 80, new DateTime(2024, 10, 4, 21, 4, 54, 634, DateTimeKind.Local).AddTicks(1630), 120 },
                    { 2, 90, new DateTime(2024, 10, 4, 21, 4, 54, 634, DateTimeKind.Local).AddTicks(1681), 100 },
                    { 3, 80, new DateTime(2024, 10, 4, 21, 4, 54, 634, DateTimeKind.Local).AddTicks(1684), 110 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements");
        }
    }
}
