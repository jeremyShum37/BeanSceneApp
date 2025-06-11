using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneApp.Migrations
{
    /// <inheritdoc />
    public partial class beanmem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_User_MemberId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Reservations",
                newName: "MemberUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_MemberId",
                table: "Reservations",
                newName: "IX_Reservations_MemberUserId");

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

            migrationBuilder.RenameColumn(
                name: "MemberUserId",
                table: "Reservations",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_MemberUserId",
                table: "Reservations",
                newName: "IX_Reservations_MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_User_MemberId",
                table: "Reservations",
                column: "MemberId",
                principalTable: "User",
                principalColumn: "UserId");
        }
    }
}
