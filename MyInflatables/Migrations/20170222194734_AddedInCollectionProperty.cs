using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyInflatables.Migrations
{
    public partial class AddedInCollectionProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Toys",
                nullable: false);

            migrationBuilder.AddColumn<bool>(
                name: "InCollection",
                table: "Toys",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InCollection",
                table: "Toys");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Toys",
                nullable: false,
                defaultValue: 1);
        }
    }
}
