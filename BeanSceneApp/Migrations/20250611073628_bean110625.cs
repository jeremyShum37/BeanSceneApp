using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneApp.Migrations
{
    /// <inheritdoc />
    public partial class bean110625 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_User_MemberId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Sittings");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Sittings");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Reservations",
                newName: "MemberUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_MemberId",
                table: "Reservations",
                newName: "IX_Reservations_MemberUserId");

            migrationBuilder.AddColumn<string>(
                name: "TableCode",
                table: "Sittings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_User_MemberUserId",
                table: "Reservations",
                column: "MemberUserId",
                principalTable: "User",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_User_MemberUserId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TableCode",
                table: "Sittings");

            migrationBuilder.RenameColumn(
                name: "MemberUserId",
                table: "Reservations",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_MemberUserId",
                table: "Reservations",
                newName: "IX_Reservations_MemberId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Sittings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Sittings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_User_MemberId",
                table: "Reservations",
                column: "MemberId",
                principalTable: "User",
                principalColumn: "UserId");
        }
    }
}
