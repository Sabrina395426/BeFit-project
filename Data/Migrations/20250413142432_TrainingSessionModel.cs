using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeFit.Data.Migrations
{
    /// <inheritdoc />
    public partial class TrainingSessionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingSession_AspNetUsers_UserId",
                table: "TrainingSession");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TrainingSession",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingSession_AspNetUsers_UserId",
                table: "TrainingSession",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingSession_AspNetUsers_UserId",
                table: "TrainingSession");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TrainingSession",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingSession_AspNetUsers_UserId",
                table: "TrainingSession",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
