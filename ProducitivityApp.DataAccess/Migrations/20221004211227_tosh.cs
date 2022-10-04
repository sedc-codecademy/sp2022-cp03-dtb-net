using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProducitivityApp.DataAccess.Migrations
{
    public partial class tosh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reminders",
                columns: table => new
                {
                    ReminderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReminderTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReminderNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReminderDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReminderTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminders", x => x.ReminderId);
                    table.ForeignKey(
                        name: "FK_Reminders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_UserId",
                table: "Reminders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reminders");
        }
    }
}
