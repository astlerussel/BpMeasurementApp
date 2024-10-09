using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BpMeasurementApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Positions_PositionID",
                table: "Measurements");

            migrationBuilder.AlterColumn<string>(
                name: "PositionID",
                table: "Measurements",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 1,
                column: "MeasurementDate",
                value: new DateTime(2024, 10, 6, 23, 20, 28, 768, DateTimeKind.Local).AddTicks(5651));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 2,
                column: "MeasurementDate",
                value: new DateTime(2024, 10, 5, 23, 20, 28, 768, DateTimeKind.Local).AddTicks(5701));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Diastolic", "MeasurementDate", "Systolic" },
                values: new object[] { 70, new DateTime(2024, 10, 4, 23, 20, 28, 768, DateTimeKind.Local).AddTicks(5708), 120 });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Id", "Diastolic", "MeasurementDate", "PositionID", "Systolic" },
                values: new object[,]
                {
                    { 4, 90, new DateTime(2024, 10, 3, 23, 20, 28, 768, DateTimeKind.Local).AddTicks(5710), "S", 130 },
                    { 5, 80, new DateTime(2024, 10, 2, 23, 20, 28, 768, DateTimeKind.Local).AddTicks(5712), "L", 140 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Positions_PositionID",
                table: "Measurements",
                column: "PositionID",
                principalTable: "Positions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Positions_PositionID",
                table: "Measurements");

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "PositionID",
                table: "Measurements",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 1,
                column: "MeasurementDate",
                value: new DateTime(2024, 10, 4, 23, 34, 38, 764, DateTimeKind.Local).AddTicks(2142));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 2,
                column: "MeasurementDate",
                value: new DateTime(2024, 10, 3, 23, 34, 38, 764, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Diastolic", "MeasurementDate", "Systolic" },
                values: new object[] { 90, new DateTime(2024, 10, 2, 23, 34, 38, 764, DateTimeKind.Local).AddTicks(2191), 140 });

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Positions_PositionID",
                table: "Measurements",
                column: "PositionID",
                principalTable: "Positions",
                principalColumn: "ID");
        }
    }
}
