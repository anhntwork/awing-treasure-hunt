using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTable_TreasureHuntRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "TreasureHuntRequests");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TreasureHuntRequests",
                newName: "Matrix");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TreasureHuntRequests",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TreasureHuntRequests",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "M",
                table: "TreasureHuntRequests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "N",
                table: "TreasureHuntRequests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "P",
                table: "TreasureHuntRequests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Result",
                table: "TreasureHuntRequests",
                type: "REAL",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TreasureHuntRequests");

            migrationBuilder.DropColumn(
                name: "M",
                table: "TreasureHuntRequests");

            migrationBuilder.DropColumn(
                name: "N",
                table: "TreasureHuntRequests");

            migrationBuilder.DropColumn(
                name: "P",
                table: "TreasureHuntRequests");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "TreasureHuntRequests");

            migrationBuilder.RenameColumn(
                name: "Matrix",
                table: "TreasureHuntRequests",
                newName: "Description");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TreasureHuntRequests",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TreasureHuntRequests",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
