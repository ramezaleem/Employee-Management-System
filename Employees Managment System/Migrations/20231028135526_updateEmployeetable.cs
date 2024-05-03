using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employees_Managment_System.Migrations
{
    /// <inheritdoc />
    public partial class updateEmployeetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmpTitle",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpTitle",
                table: "Employees");
        }
    }
}
