using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorScrumAPI.Migrations
{
    public partial class DbSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoardID = table.Column<int>(type: "int", nullable: false),
                    StateID = table.Column<int>(type: "int", nullable: false),
                    AssigneeID = table.Column<int>(type: "int", nullable: false),
                    ReporterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardID",
                        column: x => x.BoardID,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_States_StateID",
                        column: x => x.StateID,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_AssigneeID",
                        column: x => x.AssigneeID,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Users_ReporterID",
                        column: x => x.ReporterID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "BoardOne" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "To Do" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Username" },
                values: new object[,]
                {
                    { 1, "Alex Lackovic" },
                    { 2, "Benjamin Roesdal" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssigneeID",
                table: "Tasks",
                column: "AssigneeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardID",
                table: "Tasks",
                column: "BoardID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ReporterID",
                table: "Tasks",
                column: "ReporterID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StateID",
                table: "Tasks",
                column: "StateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
