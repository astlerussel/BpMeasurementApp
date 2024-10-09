using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BpMeasurementApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PositionID",
                table: "Measurements",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MeasurementDate", "PositionID" },
                values: new object[] { new DateTime(2024, 10, 4, 23, 34, 38, 764, DateTimeKind.Local).AddTicks(2142), "S" });

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Diastolic", "MeasurementDate", "PositionID", "Systolic" },
                values: new object[] { 85, new DateTime(2024, 10, 3, 23, 34, 38, 764, DateTimeKind.Local).AddTicks(2187), "L", 130 });

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Diastolic", "MeasurementDate", "PositionID", "Systolic" },
                values: new object[] { 90, new DateTime(2024, 10, 2, 23, 34, 38, 764, DateTimeKind.Local).AddTicks(2191), "ST", 140 });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { "L", "Lying down" },
                    { "S", "Sitting" },
                    { "ST", "Standing" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_PositionID",
                table: "Measurements",
                column: "PositionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Positions_PositionID",
                table: "Measurements",
                column: "PositionID",
                principalTable: "Positions",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Positions_PositionID",
                table: "Measurements");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_PositionID",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "PositionID",
                table: "Measurements");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 1,
                column: "MeasurementDate",
                value: new DateTime(2024, 10, 4, 21, 4, 54, 634, DateTimeKind.Local).AddTicks(1630));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Diastolic", "MeasurementDate", "Systolic" },
                values: new object[] { 90, new DateTime(2024, 10, 4, 21, 4, 54, 634, DateTimeKind.Local).AddTicks(1681), 100 });

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Diastolic", "MeasurementDate", "Systolic" },
                values: new object[] { 80, new DateTime(2024, 10, 4, 21, 4, 54, 634, DateTimeKind.Local).AddTicks(1684), 110 });
        }
    }
}
