using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoConnectRepositoty.Migrations
{
    /// <inheritdoc />
    public partial class Samopp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DoConnects",
                table: "DoConnects");

            migrationBuilder.RenameTable(
                name: "DoConnects",
                newName: "DoConnectRegs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoConnectRegs",
                table: "DoConnectRegs",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DoConnectRegs",
                table: "DoConnectRegs");

            migrationBuilder.RenameTable(
                name: "DoConnectRegs",
                newName: "DoConnects");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoConnects",
                table: "DoConnects",
                column: "Id");
        }
    }
}
