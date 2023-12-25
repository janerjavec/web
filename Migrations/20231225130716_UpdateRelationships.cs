using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Guest_Id",
                table: "Reservation",
                column: "Guest_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Guest_Guest_Id",
                table: "Reservation",
                column: "Guest_Id",
                principalTable: "Guest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Guest_Guest_Id",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_Guest_Id",
                table: "Reservation");
        }
    }
}
