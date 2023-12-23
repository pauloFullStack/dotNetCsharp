using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    public partial class AddDateColumnsToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Categories",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Categories",
                type: "datetime(6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Categories");
        }
    }
}
