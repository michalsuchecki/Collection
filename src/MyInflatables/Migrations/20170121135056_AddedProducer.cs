using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyInflatables.Migrations
{
    public partial class AddedProducer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProducerId",
                table: "Toys",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    ProducerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.ProducerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Toys_ProducerId",
                table: "Toys",
                column: "ProducerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toys_Producers_ProducerId",
                table: "Toys",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "ProducerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toys_Producers_ProducerId",
                table: "Toys");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropIndex(
                name: "IX_Toys_ProducerId",
                table: "Toys");

            migrationBuilder.DropColumn(
                name: "ProducerId",
                table: "Toys");
        }
    }
}
