using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketsLayer.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Dept_id", "Description", "IsClosed", "Severity", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Rerum totam est quo possimus sunt sunt ad.", false, 0, "id" },
                    { 2, 3, "Id cumque explicabo beatae.", false, 1, "dicta" },
                    { 3, 2, "Consectetur beatae dolorem voluptates occaecati.", false, 0, "eius" },
                    { 4, 1, "Nulla est doloribus ut non aspernatur vero dolores.", false, 2, "assumenda" },
                    { 5, 2, "Et praesentium est ipsum eligendi rerum itaque voluptate quia.", false, 1, "ex" },
                    { 6, 3, "Optio non debitis ut molestiae dolorem ad.", false, 2, "velit" },
                    { 20, 2, "Harum hic impedit dolore voluptate placeat.", true, 1, "in" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Tickets");
        }
    }
}
