using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketsLayer.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Departments_DepartmentId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_DepartmentId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "Dept_id",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Dept_id",
                table: "Tickets",
                column: "Dept_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Departments_Dept_id",
                table: "Tickets",
                column: "Dept_id",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Departments_Dept_id",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_Dept_id",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Dept_id",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_DepartmentId",
                table: "Tickets",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Departments_DepartmentId",
                table: "Tickets",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
