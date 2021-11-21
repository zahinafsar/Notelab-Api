using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace notelab.app.Migrations
{
    public partial class FixedDataRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notes_users_UsersId",
                table: "notes");

            migrationBuilder.AlterColumn<int>(
                name: "UsersId",
                table: "notes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_notes_users_UsersId",
                table: "notes",
                column: "UsersId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notes_users_UsersId",
                table: "notes");

            migrationBuilder.AlterColumn<int>(
                name: "UsersId",
                table: "notes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_notes_users_UsersId",
                table: "notes",
                column: "UsersId",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
