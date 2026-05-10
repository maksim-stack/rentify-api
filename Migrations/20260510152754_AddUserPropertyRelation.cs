using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalApp.Migrations
{
    /// <inheritdoc />
    public partial class AddUserPropertyRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Properties_OwnerId",
                table: "Properties",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Users_OwnerId",
                table: "Properties",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Users_OwnerId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_OwnerId",
                table: "Properties");
        }
    }
}
