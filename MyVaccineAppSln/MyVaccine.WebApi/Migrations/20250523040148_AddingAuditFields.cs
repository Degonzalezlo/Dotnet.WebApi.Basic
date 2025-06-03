using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVaccine.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddingAuditFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "VaccinesRecord",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "VaccinesRecord",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Vaccines",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Vaccines",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "VaccineCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "VaccineCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "FamilyGroups",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "FamilyGroups",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Dependents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Dependents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Allergies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Allergies",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "VaccinesRecord");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "VaccinesRecord");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "VaccineCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "VaccineCategories");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "FamilyGroups");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "FamilyGroups");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Dependents");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Dependents");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Allergies");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Allergies");
        }
    }
}
