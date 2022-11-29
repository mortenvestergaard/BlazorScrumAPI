using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorScrumAPI.Migrations
{
    public partial class AddedTestBoardAndTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskID",
                table: "Boards");

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "BoardOne" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "AssigneeID", "BoardID", "Description", "ReporterID", "StateID", "Title" },
                values: new object[] { 1, 1, 1, "Do the thing with the code", 2, 1, "Do some code" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "AssigneeID", "BoardID", "Description", "ReporterID", "StateID", "Title" },
                values: new object[] { 2, 1, 1, "Do the other thing with the code", 2, 2, "Check some code" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "AssigneeID", "BoardID", "Description", "ReporterID", "StateID", "Title" },
                values: new object[] { 3, 2, 1, "I really dont know", 1, 3, "What now" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "TaskID",
                table: "Boards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
