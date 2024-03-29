using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymSpotterAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Mg7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOuts_WorkOuts_workOutId",
                table: "WorkOuts");

            migrationBuilder.DropIndex(
                name: "IX_WorkOuts_workOutId",
                table: "WorkOuts");

            migrationBuilder.RenameColumn(
                name: "workOutId",
                table: "WorkOuts",
                newName: "WorkOutType");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayNameWorkOut",
                table: "WorkOuts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkOutType",
                table: "WorkOuts",
                newName: "workOutId");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayNameWorkOut",
                table: "WorkOuts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkOuts_workOutId",
                table: "WorkOuts",
                column: "workOutId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOuts_WorkOuts_workOutId",
                table: "WorkOuts",
                column: "workOutId",
                principalTable: "WorkOuts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
