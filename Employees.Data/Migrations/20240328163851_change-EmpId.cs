using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employees.Data.Migrations
{
    public partial class changeEmpId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "EmpRoles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "EmpRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
