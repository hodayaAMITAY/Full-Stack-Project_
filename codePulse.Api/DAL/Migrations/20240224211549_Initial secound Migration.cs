using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialsecoundMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userid",
                table: "Klips");

            migrationBuilder.RenameColumn(
                name: "categoryid",
                table: "Klips",
                newName: "CategoryId");

            migrationBuilder.AddColumn<Guid>(
                name: "RegisterId",
                table: "Klips",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RegisterId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Klips_CategoryId",
                table: "Klips",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Klips_RegisterId",
                table: "Klips",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_RegisterId",
                table: "Categories",
                column: "RegisterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Registers_RegisterId",
                table: "Categories",
                column: "RegisterId",
                principalTable: "Registers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Klips_Categories_CategoryId",
                table: "Klips",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Klips_Registers_RegisterId",
                table: "Klips",
                column: "RegisterId",
                principalTable: "Registers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Registers_RegisterId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Klips_Categories_CategoryId",
                table: "Klips");

            migrationBuilder.DropForeignKey(
                name: "FK_Klips_Registers_RegisterId",
                table: "Klips");

            migrationBuilder.DropIndex(
                name: "IX_Klips_CategoryId",
                table: "Klips");

            migrationBuilder.DropIndex(
                name: "IX_Klips_RegisterId",
                table: "Klips");

            migrationBuilder.DropIndex(
                name: "IX_Categories_RegisterId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "RegisterId",
                table: "Klips");


            migrationBuilder.DropColumn(
                name: "RegisterId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Klips",
                newName: "categoryid");

            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "Klips",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
