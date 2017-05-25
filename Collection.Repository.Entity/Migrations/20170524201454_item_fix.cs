using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Collection.Repository.Entity.Migrations
{
    public partial class item_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Producers_CategoryProducerId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Producers_Items_ItemId",
                table: "Producers");

            migrationBuilder.DropIndex(
                name: "IX_Producers_ItemId",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Producers");

            migrationBuilder.RenameColumn(
                name: "CategoryProducerId",
                table: "Items",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CategoryProducerId",
                table: "Items",
                newName: "IX_Items_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Items",
                newName: "CategoryProducerId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                newName: "IX_Items_CategoryProducerId");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Producers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producers_ItemId",
                table: "Producers",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Producers_CategoryProducerId",
                table: "Items",
                column: "CategoryProducerId",
                principalTable: "Producers",
                principalColumn: "ProducerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producers_Items_ItemId",
                table: "Producers",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
