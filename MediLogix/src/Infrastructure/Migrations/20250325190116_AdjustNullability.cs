using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediLogix.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdjustNullability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Devices_CurrentLocationId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_DescriptionId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_FinancialInfoId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_ModelId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_OperatingTermsId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_PeriodicVerificationId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_WarrantyAndMaintenanceId",
                table: "Devices");

            migrationBuilder.AlterColumn<Guid>(
                name: "WarrantyAndMaintenanceId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "PeriodicVerificationId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "OperatingTermsId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ModelId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "FinancialInfoId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "DescriptionId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrentLocationId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_CurrentLocationId",
                table: "Devices",
                column: "CurrentLocationId",
                unique: true,
                filter: "[CurrentLocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DescriptionId",
                table: "Devices",
                column: "DescriptionId",
                unique: true,
                filter: "[DescriptionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_FinancialInfoId",
                table: "Devices",
                column: "FinancialInfoId",
                unique: true,
                filter: "[FinancialInfoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_ModelId",
                table: "Devices",
                column: "ModelId",
                unique: true,
                filter: "[ModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_OperatingTermsId",
                table: "Devices",
                column: "OperatingTermsId",
                unique: true,
                filter: "[OperatingTermsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_PeriodicVerificationId",
                table: "Devices",
                column: "PeriodicVerificationId",
                unique: true,
                filter: "[PeriodicVerificationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_WarrantyAndMaintenanceId",
                table: "Devices",
                column: "WarrantyAndMaintenanceId",
                unique: true,
                filter: "[WarrantyAndMaintenanceId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Devices_CurrentLocationId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_DescriptionId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_FinancialInfoId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_ModelId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_OperatingTermsId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_PeriodicVerificationId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_WarrantyAndMaintenanceId",
                table: "Devices");

            migrationBuilder.AlterColumn<Guid>(
                name: "WarrantyAndMaintenanceId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PeriodicVerificationId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OperatingTermsId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModelId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FinancialInfoId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DescriptionId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrentLocationId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_CurrentLocationId",
                table: "Devices",
                column: "CurrentLocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DescriptionId",
                table: "Devices",
                column: "DescriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_FinancialInfoId",
                table: "Devices",
                column: "FinancialInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_ModelId",
                table: "Devices",
                column: "ModelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_OperatingTermsId",
                table: "Devices",
                column: "OperatingTermsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_PeriodicVerificationId",
                table: "Devices",
                column: "PeriodicVerificationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_WarrantyAndMaintenanceId",
                table: "Devices",
                column: "WarrantyAndMaintenanceId",
                unique: true);
        }
    }
}
