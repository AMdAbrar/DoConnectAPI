using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoConnectRepositoty.Migrations
{
    /// <inheritdoc />
    public partial class Samop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "DoConnects");

            migrationBuilder.DropColumn(
                name: "P_No",
                table: "DoConnects");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "DoConnects",
                newName: "ConfirmPassword");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConfirmPassword",
                table: "DoConnects",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "DoConnects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "P_No",
                table: "DoConnects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
