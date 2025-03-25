using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediLogix.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdjustPeriodicVerifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerificationPeriodicity",
                table: "PeriodicVerifications");

            migrationBuilder.AddColumn<short>(
                name: "VerificationPeriodicityMonths",
                table: "PeriodicVerifications",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerificationPeriodicityMonths",
                table: "PeriodicVerifications");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "VerificationPeriodicity",
                table: "PeriodicVerifications",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
