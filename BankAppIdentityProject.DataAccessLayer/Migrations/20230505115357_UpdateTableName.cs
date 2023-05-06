using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAppIdentityProject.DataAccessLayer.Migrations
{
    public partial class UpdateTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                migrationBuilder.DropPrimaryKey(
                name: "PK_customerAccountProcesses",
                table: "customerAccountProcesses");

            migrationBuilder.RenameTable(
                name: "customerAccountProcesses",
                newName: "CustomerAccountProcesses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerAccountProcesses",
                table: "CustomerAccountProcesses",
                column: "CustomerAccountProcessID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerAccountProcesses",
                table: "CustomerAccountProcesses");

            migrationBuilder.RenameTable(
                name: "CustomerAccountProcesses",
                newName: "customerAccountProcesses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customerAccountProcesses",
                table: "customerAccountProcesses",
                column: "CustomerAccountProcessID");
        }
    }
}
